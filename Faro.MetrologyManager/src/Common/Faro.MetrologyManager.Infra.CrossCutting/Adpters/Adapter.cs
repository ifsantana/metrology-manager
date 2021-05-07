using AutoMapper;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;

namespace Faro.MetrologyManager.Infra.CrossCutting.Adapters   
{
	public class Adapter
		: IAdapter
	{
		private readonly IMapper _mapper;

		public Adapter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public TTo Adapt<TTo>(object from) => _mapper.Map<TTo>(from);
	}
}
