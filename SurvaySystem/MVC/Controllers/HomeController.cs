using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using SurvaySystem.ApplicationProject.Interfaces.Service;
using SurvaySystem.DomainProject.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITblKPIService _service;

        public HomeController(ILogger<HomeController> logger, ITblKPIService service)
        {
            _logger = logger;
            _service = service;
        }

     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetDataSource()
        {  
            var data =await _service.GetAll();
            if (data.Success)
            {
                var result = new DataSourceResult()
                {
                    Data = data.Data,
                    Total = data.Data.Count()
                };

                return Json(result);
            }
            return Json(new DataSourceResult());
        }
        [HttpPost]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<AddTblKPIDTO> addTblKPIDTOs)
        {
            List<AddTblKPIDTO> result = new();
            #region Guard
            if (ModelState.IsValid && addTblKPIDTOs.Any())
            {
                var response = await _service.AddTBlKPI(addTblKPIDTOs);
                if(response.Success)
                    return Json(response.Data.ToDataSourceResult(request, ModelState));
            }
            #endregion
            return Json(result.ToDataSourceResult(request, ModelState));
        }
        [HttpPut]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<UpdateTblKPIDTO> updateTblKPIDTOs)
        {
            List<UpdateTblKPIDTO> result = new();
            #region Guard
            if (ModelState.IsValid && updateTblKPIDTOs.Any())
            {
                var response = await _service.UpdateTBlKPI(updateTblKPIDTOs);
                if (response.Success)
                    return Json(updateTblKPIDTOs.ToDataSourceResult(request, ModelState));
            }
            #endregion
            return Json(result.ToDataSourceResult(request, ModelState));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<GetTblKPIDTO> dtos)
        {
            #region Guard
            if (ModelState.IsValid && dtos.Any())
            {
                var response = await _service.DeleteTBlKPI(dtos.Select(a => a.Id));
                if (response.Success)
                     return Json(dtos.ToDataSourceResult(request, ModelState));
            }
            #endregion
            return Json(dtos.ToDataSourceResult(request, ModelState));

        }
      
     
    }

}

