using System.Collections.Generic;
using MyCompany.MyModuleCodeBehind.Models;

namespace MyCompany.MyModuleCodeBehind.Repository
{
    public interface IMyModuleCodeBehindRepository
    {
        IEnumerable<Models.MyModuleCodeBehind> GetMyModuleCodeBehinds(int ModuleId);
        Models.MyModuleCodeBehind GetMyModuleCodeBehind(int MyModuleCodeBehindId);
        Models.MyModuleCodeBehind GetMyModuleCodeBehind(int MyModuleCodeBehindId, bool tracking);
        Models.MyModuleCodeBehind AddMyModuleCodeBehind(Models.MyModuleCodeBehind MyModuleCodeBehind);
        Models.MyModuleCodeBehind UpdateMyModuleCodeBehind(Models.MyModuleCodeBehind MyModuleCodeBehind);
        void DeleteMyModuleCodeBehind(int MyModuleCodeBehindId);
    }
}
