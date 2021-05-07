using Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Base.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModels.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Base
{
    public abstract class DataModelRepositoryBase<TDataModel>
		: IDataModelRepository<TDataModel>
		where TDataModel : DataModelBase
	{
		private readonly IDbContext _dbContext;

		
		protected ILogger Logger { get; }
		protected IAdapter Adapter { get; }
		protected DbSet<TDataModel> DbSet { get; }

		
		protected DataModelRepositoryBase(ILogger logger, IAdapter adapter, IDbContext dbContext)
		{
			_dbContext = dbContext;

			Adapter = adapter;
			Logger = logger;
			DbSet = _dbContext.Set<TDataModel>();
		}

		// Private Methods
		private static void SetModifiedProperties(EntityEntry<TDataModel> entry, TDataModel dataModel)
		{
			var changedProperties = dataModel.GetPropertyChangedCollection().Where(q => q != nameof(DataModelBase.Id));

			var properties = changedProperties as string[] ?? changedProperties.ToArray();

			if (!properties.Any())
				return;

			foreach (var property in entry.Properties)
				property.IsModified =
					properties.Contains(
						property.Metadata.PropertyInfo.Name);
		}

		// Public Methods
		public async Task<TDataModel> AddAsync(TDataModel dataModel, CancellationToken cancellationToken)
		{
			return (await DbSet.AddAsync(dataModel, cancellationToken).ConfigureAwait(false)).Entity;
		}

		public Task<TDataModel> UpdateAsync(TDataModel dataModel, CancellationToken cancellationToken)
		{
			var localDataModel = DbSet.Local.FirstOrDefault(q => q.Id == dataModel.Id);

			var entry = _dbContext.Entry(localDataModel ?? dataModel);
			entry.State = EntityState.Modified;

			SetModifiedProperties(entry, dataModel);

			return Task.FromResult(entry.Entity);
		}

		public Task RemoveAsync(Guid id, CancellationToken cancellationToken)
		{
			var localDataModel = DbSet.Local.FirstOrDefault(q => q.Id == id);
			var dataModel = Activator.CreateInstance<TDataModel>();
			dataModel.Id = id;

			DbSet.Remove(localDataModel ?? dataModel);

			return Task.CompletedTask;
		}
		public Task RemoveAsync(TDataModel dataModel, CancellationToken cancellationToken)
		{
			DbSet.Remove(dataModel);

			return Task.CompletedTask;
		}
		public async Task<TDataModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			var dbResult = await DbSet.AsNoTracking().Where(q => q.Id == id).ToArrayAsync(cancellationToken).ConfigureAwait(false);

			var offlineResult = DbSet.Local.Where(q => q.Id == id);

			return offlineResult.Union(dbResult).FirstOrDefault();
		}

		public async Task<IEnumerable<TDataModel>> GetAllAsync(CancellationToken cancellationToken)
		{
			var dbResult = await DbSet.AsNoTracking().ToArrayAsync(cancellationToken).ConfigureAwait(false);

			var offlineResult = DbSet.Local;

			return offlineResult.Union(dbResult);
		}

		public async Task<IEnumerable<TDataModel>> FindAsync(Expression<Func<TDataModel, bool>> expression, CancellationToken cancellationToken)
		{
			var result = await Task.FromResult(FindQueryable(expression)).ConfigureAwait(false);

			return result;
		}

		protected IQueryable<TDataModel> FindQueryable(Expression<Func<TDataModel, bool>> expression)
		{
			var dbResult = DbSet.AsNoTracking().Where(expression).ToList();

			var offlineResult = DbSet.Local.Where(expression.Compile()).AsQueryable();

			return offlineResult.Union(dbResult);
		}

		protected IQueryable<TDataModel> FindQueryable<TProperty>(Expression<Func<TDataModel, bool>> expression, Expression<Func<TDataModel, TProperty>> includeExpression)
		{
			var dbResult = DbSet.AsNoTracking().Include(includeExpression).Where(expression).ToList();

			var offlineResult = DbSet.Local.Where(expression.Compile()).AsQueryable();

			return offlineResult.Union(dbResult);
		}
	}
}
