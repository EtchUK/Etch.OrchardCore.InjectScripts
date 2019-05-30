using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Shell.Descriptor.Models;
using OrchardCore.Navigation;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.InjectScripts
{
    public class AdminMenu : INavigationProvider
    {
        private readonly ShellDescriptor _shellDescriptor;

        public AdminMenu(IStringLocalizer<AdminMenu> localizer, ShellDescriptor shellDescriptor)
        {
            T = localizer;
            _shellDescriptor = shellDescriptor;
        }

        public IStringLocalizer T { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(T["Configuration"], content => content
                .Add(T["Scripts"], "10", contentItems => contentItems
                    .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = Constants.GroupId })
                    .LocalNav())
                );

            return Task.CompletedTask;
        }
    }
}
