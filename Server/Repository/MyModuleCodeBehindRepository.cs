using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using MyCompany.MyModuleCodeBehind.Models;

namespace MyCompany.MyModuleCodeBehind.Repository
{
    public class MyModuleCodeBehindRepository : IMyModuleCodeBehindRepository, IService
    {
        private readonly MyModuleCodeBehindContext _db;

        public MyModuleCodeBehindRepository(MyModuleCodeBehindContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.MyModuleCodeBehind> GetMyModuleCodeBehinds(int ModuleId)
        {
            return _db.MyModuleCodeBehind.Where(item => item.ModuleId == ModuleId);
        }

        public Models.MyModuleCodeBehind GetMyModuleCodeBehind(int MyModuleCodeBehindId)
        {
            return GetMyModuleCodeBehind(MyModuleCodeBehindId, true);
        }

        public Models.MyModuleCodeBehind GetMyModuleCodeBehind(int MyModuleCodeBehindId, bool tracking)
        {
            if (tracking)
            {
                return _db.MyModuleCodeBehind.Find(MyModuleCodeBehindId);
            }
            else
            {
                return _db.MyModuleCodeBehind.AsNoTracking().FirstOrDefault(item => item.MyModuleCodeBehindId == MyModuleCodeBehindId);
            }
        }

        public Models.MyModuleCodeBehind AddMyModuleCodeBehind(Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            _db.MyModuleCodeBehind.Add(MyModuleCodeBehind);
            _db.SaveChanges();
            return MyModuleCodeBehind;
        }

        public Models.MyModuleCodeBehind UpdateMyModuleCodeBehind(Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            _db.Entry(MyModuleCodeBehind).State = EntityState.Modified;
            _db.SaveChanges();
            return MyModuleCodeBehind;
        }

        public void DeleteMyModuleCodeBehind(int MyModuleCodeBehindId)
        {
            Models.MyModuleCodeBehind MyModuleCodeBehind = _db.MyModuleCodeBehind.Find(MyModuleCodeBehindId);
            _db.MyModuleCodeBehind.Remove(MyModuleCodeBehind);
            _db.SaveChanges();
        }
    }
}
