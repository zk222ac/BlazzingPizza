//using BlazzingPizza.LoggingService.Contracts;
//using BlazzingPizza.LoggingService.LoggerService;

namespace BlazzingPizza.Server.Extensions
{
    public static class ServiceExtensions
    {
        //  CORS (Cross-Origin Resource Sharing) is a mechanism that gives
        //  rights to the user to access resources from the server on a different domain.
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        }
        // configure an IIS integration that will help us with the IIS deployment
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        // Configure Logger Service extension method
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
           // services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}
