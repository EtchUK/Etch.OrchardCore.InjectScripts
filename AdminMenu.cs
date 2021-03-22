using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Shell.Descriptor.Models;
using OrchardCore.Navigation;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.InjectScripts
{
    public class AdminMenu : INavigationProvider
    { 
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            S = localizer;
        }

        public IStringLocalizer S { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(S["Configuration"], content => content
                .Add(S["Scripts"], S["Scripts"].PrefixPosition(), contentItems => contentItems
                    .AddClass("scripts").Id("scripts")
                    .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = Constants.GroupId })
                    .Permission(Permissions.ManageInjectScripts)
                    .LocalNav())
                );

            return Task.CompletedTask;
        }
    }
}
