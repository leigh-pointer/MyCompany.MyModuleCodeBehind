using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using MyCompany.MyModuleCodeBehind.Repository;

namespace MyCompany.MyModuleCodeBehind.Manager
{
    public class MyModuleCodeBehindManager : MigratableModuleBase, IInstallable, IPortable
    {
        private IMyModuleCodeBehindRepository _MyModuleCodeBehindRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public MyModuleCodeBehindManager(IMyModuleCodeBehindRepository MyModuleCodeBehindRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _MyModuleCodeBehindRepository = MyModuleCodeBehindRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new MyModuleCodeBehindContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new MyModuleCodeBehindContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.MyModuleCodeBehind> MyModuleCodeBehinds = _MyModuleCodeBehindRepository.GetMyModuleCodeBehinds(module.ModuleId).ToList();
            if (MyModuleCodeBehinds != null)
            {
                content = JsonSerializer.Serialize(MyModuleCodeBehinds);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.MyModuleCodeBehind> MyModuleCodeBehinds = null;
            if (!string.IsNullOrEmpty(content))
            {
                MyModuleCodeBehinds = JsonSerializer.Deserialize<List<Models.MyModuleCodeBehind>>(content);
            }
            if (MyModuleCodeBehinds != null)
            {
                foreach(var MyModuleCodeBehind in MyModuleCodeBehinds)
                {
                    _MyModuleCodeBehindRepository.AddMyModuleCodeBehind(new Models.MyModuleCodeBehind { ModuleId = module.ModuleId, Name = MyModuleCodeBehind.Name });
                }
            }
        }
    }
}