using Microsoft.AspNetCore.Builder;

namespace Faro.MetrologyManager.Ports.Api.Middlewares
{
    public static class UseExceptionLogHandlerExtension
    {
        public static IApplicationBuilder UseExceptionLogHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<UseExceptionLogHandler>();
    }
}
