using OrchardCore.Security.Permissions;
using System.Collections.Generic;

namespace Etch.OrchardCore.InjectScripts
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageInjectScripts = new Permission("InjectScipts", "Manage Inject Scripts");

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageInjectScripts };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageInjectScripts }
                }
            };
        }
    }
}