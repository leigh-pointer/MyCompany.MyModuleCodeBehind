using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using MyCompany.MyModuleCodeBehind.Repository;
using Oqtane.Controllers;
using System.Net;

namespace MyCompany.MyModuleCodeBehind.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class MyModuleCodeBehindController : ModuleControllerBase
    {
        private readonly IMyModuleCodeBehindRepository _MyModuleCodeBehindRepository;

        public MyModuleCodeBehindController(IMyModuleCodeBehindRepository MyModuleCodeBehindRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _MyModuleCodeBehindRepository = MyModuleCodeBehindRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.MyModuleCodeBehind> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && ModuleId == AuthEntityId(EntityNames.Module))
            {
                return _MyModuleCodeBehindRepository.GetMyModuleCodeBehinds(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MyModuleCodeBehind Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.MyModuleCodeBehind Get(int id)
        {
            Models.MyModuleCodeBehind MyModuleCodeBehind = _MyModuleCodeBehindRepository.GetMyModuleCodeBehind(id);
            if (MyModuleCodeBehind != null && MyModuleCodeBehind.ModuleId == AuthEntityId(EntityNames.Module))
            {
                return MyModuleCodeBehind;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MyModuleCodeBehind Get Attempt {MyModuleCodeBehindId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.MyModuleCodeBehind Post([FromBody] Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            if (ModelState.IsValid && MyModuleCodeBehind.ModuleId == AuthEntityId(EntityNames.Module))
            {
                MyModuleCodeBehind = _MyModuleCodeBehindRepository.AddMyModuleCodeBehind(MyModuleCodeBehind);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "MyModuleCodeBehind Added {MyModuleCodeBehind}", MyModuleCodeBehind);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MyModuleCodeBehind Post Attempt {MyModuleCodeBehind}", MyModuleCodeBehind);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                MyModuleCodeBehind = null;
            }
            return MyModuleCodeBehind;
        }

        // PUT api/<controller>/5
        [ValidateAntiForgeryToken]
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.MyModuleCodeBehind Put(int id, [FromBody] Models.MyModuleCodeBehind MyModuleCodeBehind)
        {
            if (ModelState.IsValid && MyModuleCodeBehind.ModuleId == AuthEntityId(EntityNames.Module) && _MyModuleCodeBehindRepository.GetMyModuleCodeBehind(MyModuleCodeBehind.MyModuleCodeBehindId, false) != null)
            {
                MyModuleCodeBehind = _MyModuleCodeBehindRepository.UpdateMyModuleCodeBehind(MyModuleCodeBehind);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "MyModuleCodeBehind Updated {MyModuleCodeBehind}", MyModuleCodeBehind);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MyModuleCodeBehind Put Attempt {MyModuleCodeBehind}", MyModuleCodeBehind);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                MyModuleCodeBehind = null;
            }
            return MyModuleCodeBehind;
        }

        // DELETE api/<controller>/5
        [ValidateAntiForgeryToken]
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.MyModuleCodeBehind MyModuleCodeBehind = _MyModuleCodeBehindRepository.GetMyModuleCodeBehind(id);
            if (MyModuleCodeBehind != null && MyModuleCodeBehind.ModuleId == AuthEntityId(EntityNames.Module))
            {
                _MyModuleCodeBehindRepository.DeleteMyModuleCodeBehind(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "MyModuleCodeBehind Deleted {MyModuleCodeBehindId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MyModuleCodeBehind Delete Attempt {MyModuleCodeBehindId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
