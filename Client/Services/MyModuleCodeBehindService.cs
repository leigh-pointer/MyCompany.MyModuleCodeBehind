using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using MyCompany.MyModuleCodeBehind.Models;

namespace MyCompany.MyModuleCodeBehind.Services
{
    public class MyModuleCodeBehindService : ServiceBase, IMyModuleCodeBehindService, IService
    {
        public MyModuleCodeBehindService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("MyModuleCodeBehind");

        public async Task<List<Models.MyModuleCodeBehind>> GetMyModuleCodeBehindsAsync(int ModuleId)
        {
            List<Models.MyModuleCodeBehind> MyModuleCodeBehinds = await GetJsonAsync<List<Models.MyModuleCodeBehind>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return MyModuleCodeBehinds.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.MyModuleCodeBehind> GetMyModuleCodeBehindAsync(int MyModuleCodeBehindId, int ModuleId)
        {
            return await GetJsonAsync<Models.MyModuleCodeBehind>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MyModuleCodeBehindId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.MyModuleCodeBehind> AddMyModuleCodeBehindAsync(Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            return await PostJsonAsync<Models.MyModuleCodeBehind>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, MyModuleCodeBehind.ModuleId), MyModuleCodeBehind);
        }

        public async Task<Models.MyModuleCodeBehind> UpdateMyModuleCodeBehindAsync(Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            return await PutJsonAsync<Models.MyModuleCodeBehind>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MyModuleCodeBehind.MyModuleCodeBehindId}", EntityNames.Module, MyModuleCodeBehind.ModuleId), MyModuleCodeBehind);
        }

        public async Task DeleteMyModuleCodeBehindAsync(int MyModuleCodeBehindId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{MyModuleCodeBehindId}", EntityNames.Module, ModuleId));
        }
    }
}
