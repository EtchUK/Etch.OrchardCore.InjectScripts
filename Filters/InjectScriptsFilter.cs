using Etch.OrchardCore.InjectScripts.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore.Admin;
using OrchardCore.Entities;
using OrchardCore.ResourceManagement;
using OrchardCore.Settings;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Html;

namespace Etch.OrchardCore.InjectScripts.Filters
{
    public class InjectScriptsFilter : IAsyncResultFilter
    {
        private readonly IResourceManager _resourceManager;
        private readonly ISiteService _siteService;

        public InjectScriptsFilter(
            IResourceManager resourceManager,
            ISiteService siteService)
        {
            _resourceManager = resourceManager;
            _siteService = siteService;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // should only run on the front-end for a full view
            if ((context.Result is ViewResult || context.Result is PageResult) && !AdminAttribute.IsApplied(context.HttpContext))
            {
                var settings = (await _siteService.GetSiteSettingsAsync()).As<InjectScriptsSettings>();

                if (settings.Head != null && settings.Head.Any())
                {
                    foreach (var script in settings.Head)
                    {
                        _resourceManager.RegisterHeadScript(new HtmlString(script));
                    }
                }

                if (settings.Foot != null && settings.Foot.Any())
                {
                    foreach (var script in settings.Foot)
                    {
                        _resourceManager.RegisterFootScript(new HtmlString(script));
                    }
                }
            }

            await next.Invoke();
        }
    }
}
