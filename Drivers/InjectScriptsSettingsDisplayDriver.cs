﻿using Etch.OrchardCore.InjectScripts.Settings;
using Etch.OrchardCore.InjectScripts.ViewModels;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Environment.Shell;
using OrchardCore.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.InjectScripts.Drivers
{
    public class InjectScriptsSettingsDisplayDriver : SectionDisplayDriver<ISite, InjectScriptsSettings>
    {
        #region Dependencies

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShellHost _shellHost;
        private readonly ShellSettings _shellSettings;

        #endregion

        #region Constructor

        public InjectScriptsSettingsDisplayDriver(
            IHttpContextAccessor httpContextAccessor,
            IShellHost shellHost,
            ShellSettings shellSettings)
        {
            _httpContextAccessor = httpContextAccessor;
            _shellHost = shellHost;
            _shellSettings = shellSettings;
        }

        #endregion

        #region Overrides

        public override IDisplayResult Edit(InjectScriptsSettings settings, BuildEditorContext context)
        {
            return Initialize<InjectScriptsSettingsViewModel>("InjectScriptsSettings_Edit", model =>
            {
                model.Head = settings.Head?.FirstOrDefault() ?? string.Empty;
                model.Foot = settings.Foot?.FirstOrDefault() ?? string.Empty;
            }).Location("Content:5").OnGroup(Constants.GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(InjectScriptsSettings settings, BuildEditorContext context)
        {
            if (context.GroupId == Constants.GroupId)
            {
                var model = new InjectScriptsSettingsViewModel();
                await context.Updater.TryUpdateModelAsync(model, Prefix);

                if (context.Updater.ModelState.IsValid)
                {
                    settings.Head = new string[] { model.Head };
                    settings.Foot = new string[] { model.Foot };
                }
            }

            return await EditAsync(settings, context);
        }

        #endregion
    }
}
