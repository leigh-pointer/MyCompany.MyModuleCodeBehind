using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MyCompany.MyModuleCodeBehind.Services;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.MyModuleCodeBehind
{
    public partial class Edit: ModuleBase
    {
        private ElementReference form;
        private bool validated = false;
        private int _id;
        private string _name;
        private string _createdby;
        private DateTime _createdon;
        private string _modifiedby;
        private DateTime _modifiedon;

        [Inject]
        public IMyModuleCodeBehindService MyModuleCodeBehindService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IStringLocalizer<Edit> Localizer { get; set; }

        public override SecurityAccessLevel SecurityAccessLevel => SecurityAccessLevel.Edit;

        public override string Actions => "Add,Edit";

        public override string Title => "Manage MyModuleCodeBehind";

        public override List<Resource> Resources => new List<Resource>()
        {
            new Resource { ResourceType = ResourceType.Stylesheet, Url = ModulePath() + "Module.css" }
        };

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (PageState.Action == "Edit")
                {
                    _id = Int32.Parse(PageState.QueryString["id"]);
                    Models.MyModuleCodeBehind MyModuleCodeBehind = await MyModuleCodeBehindService.GetMyModuleCodeBehindAsync(_id, ModuleState.ModuleId);
                    if (MyModuleCodeBehind != null)
                    {
                        _name = MyModuleCodeBehind.Name;
                        _createdby = MyModuleCodeBehind.CreatedBy;
                        _createdon = MyModuleCodeBehind.CreatedOn;
                        _modifiedby = MyModuleCodeBehind.ModifiedBy;
                        _modifiedon = MyModuleCodeBehind.ModifiedOn;
                    }
                }
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Loading MyModuleCodeBehind {MyModuleCodeBehindId} {Error}", _id, ex.Message);
                AddModuleMessage(Localizer["Message.LoadError"], MessageType.Error);
            }
        }

        private async Task Save()
        {
            try
            {
                validated = true;
                var interop = new Oqtane.UI.Interop(JSRuntime);
                if (await interop.FormValid(form))
                {
                    if (PageState.Action == "Add")
                    {
                        Models.MyModuleCodeBehind MyModuleCodeBehind = new Models.MyModuleCodeBehind();
                        MyModuleCodeBehind.ModuleId = ModuleState.ModuleId;
                        MyModuleCodeBehind.Name = _name;
                        MyModuleCodeBehind = await MyModuleCodeBehindService.AddMyModuleCodeBehindAsync(MyModuleCodeBehind);
                        await logger.LogInformation("MyModuleCodeBehind Added {MyModuleCodeBehind}", MyModuleCodeBehind);
                    }
                    else
                    {
                        Models.MyModuleCodeBehind MyModuleCodeBehind = await MyModuleCodeBehindService.GetMyModuleCodeBehindAsync(_id, ModuleState.ModuleId);
                        MyModuleCodeBehind.Name = _name;
                        await MyModuleCodeBehindService.UpdateMyModuleCodeBehindAsync(MyModuleCodeBehind);
                        await logger.LogInformation("MyModuleCodeBehind Updated {MyModuleCodeBehind}", MyModuleCodeBehind);
                    }
                    NavigationManager.NavigateTo(NavigateUrl());
                }
                else
                {
                    AddModuleMessage(Localizer["Message.SaveValidation"], MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Saving MyModuleCodeBehind {Error}", ex.Message);
                AddModuleMessage(Localizer["Message.SaveError"], MessageType.Error);
            }
        }
    }

}

