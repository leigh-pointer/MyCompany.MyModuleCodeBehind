using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.MyModuleCodeBehind.Models;

namespace MyCompany.MyModuleCodeBehind.Services
{
    public interface IMyModuleCodeBehindService 
    {
        Task<List<Models.MyModuleCodeBehind>> GetMyModuleCodeBehindsAsync(int ModuleId);

        Task<Models.MyModuleCodeBehind> GetMyModuleCodeBehindAsync(int MyModuleCodeBehindId, int ModuleId);

        Task<Models.MyModuleCodeBehind> AddMyModuleCodeBehindAsync(Models.MyModuleCodeBehind MyModuleCodeBehind);

        Task<Models.MyModuleCodeBehind> UpdateMyModuleCodeBehindAsync(Models.MyModuleCodeBehind MyModuleCodeBehind);

        Task DeleteMyModuleCodeBehindAsync(int MyModuleCodeBehindId, int ModuleId);
    }
}
