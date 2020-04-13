using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.InjectScripts
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageInjectScripts = new Permission("InjectScipts", "Manage Inject Scripts");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageInjectScripts }.AsEnumerable());
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