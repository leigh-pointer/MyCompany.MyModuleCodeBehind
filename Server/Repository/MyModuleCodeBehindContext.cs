using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace MyCompany.MyModuleCodeBehind.Repository
{
    public class MyModuleCodeBehindContext : DBContextBase, IService, IMultiDatabase
    {
        public virtual DbSet<Models.MyModuleCodeBehind> MyModuleCodeBehind { get; set; }

        public MyModuleCodeBehindContext(ITenantManager tenantManager, IHttpContextAccessor accessor) : base(tenantManager, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
