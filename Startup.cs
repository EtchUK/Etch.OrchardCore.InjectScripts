using Etch.OrchardCore.InjectScripts.Drivers;
using Etch.OrchardCore.InjectScripts.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Settings;

namespace Etch.OrchardCore.InjectScripts
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            //services.AddRecipeExecutionStep<GoogleAnalyticsSettingsStep>();
            services.AddScoped<IDisplayDriver<ISite>, InjectScriptsSettingsDisplayDriver>();
            services.AddScoped<INavigationProvider, AdminMenu>();
            services.Configure<MvcOptions>((options) =>
            {
                options.Filters.Add(typeof(InjectScriptsFilter));
            });
        }
    }
}
