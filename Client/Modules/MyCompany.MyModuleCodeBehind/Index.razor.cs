using MyCompany.MyModuleCodeBehind.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Oqtane.Models;
using Microsoft.Extensions.Localization;
using Oqtane.Shared;
using System.Threading.Tasks;
using System;
using Oqtane.Modules;

namespace MyCompany.MyModuleCodeBehind
{
    public partial class Index : ModuleBase
    {
        List<Models.MyModuleCodeBehind> _MyModuleCodeBehinds;

        [Inject]
        public IMyModuleCodeBehindService MyModuleCodeBehindService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }
        public override List<Resource> Resources => new List<Resource>()
    {
        new Resource { ResourceType = ResourceType.Stylesheet, Url = ModulePath() + "Module.css" },
        new Resource { ResourceType = ResourceType.Script, Url = ModulePath() + "Module.js" }
    };

 
        protected override async Task OnInitializedAsync()
        {
            try
            {
                _MyModuleCodeBehinds = await MyModuleCodeBehindService.GetMyModuleCodeBehindsAsync(ModuleState.ModuleId);
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Loading MyModuleCodeBehind {Error}", ex.Message);
                AddModuleMessage(Localizer["Message.LoadError"], MessageType.Error);
            }
        }

        private async Task Delete(Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            try
            {
                await MyModuleCodeBehindService.DeleteMyModuleCodeBehindAsync(MyModuleCodeBehind.MyModuleCodeBehindId, ModuleState.ModuleId);
                await logger.LogInformation("MyModuleCodeBehind Deleted {MyModuleCodeBehind}", MyModuleCodeBehind);
                _MyModuleCodeBehinds = await MyModuleCodeBehindService.GetMyModuleCodeBehindsAsync(ModuleState.ModuleId);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Deleting MyModuleCodeBehind {MyModuleCodeBehind} {Error}", MyModuleCodeBehind, ex.Message);
                AddModuleMessage(Localizer["Message.DeleteError"], MessageType.Error);
            }
        }

    }
}
