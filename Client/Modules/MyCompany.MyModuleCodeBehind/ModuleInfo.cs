using Oqtane.Models;
using Oqtane.Modules;

namespace MyCompany.MyModuleCodeBehind
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "MyModuleCodeBehind",
            Description = "MyModuleCodeBehind",
            Version = "1.0.0",
            ServerManagerType = "MyCompany.MyModuleCodeBehind.Manager.MyModuleCodeBehindManager, MyCompany.MyModuleCodeBehind.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "MyCompany.MyModuleCodeBehind.Shared.Oqtane",
            PackageName = "MyCompany.MyModuleCodeBehind" 
        };
    }
}
