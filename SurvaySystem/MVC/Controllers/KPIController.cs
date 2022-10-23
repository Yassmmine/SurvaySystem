using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurvaySystem.ApplicationProject.Common;
using SurvaySystem.ApplicationProject.Interfaces.Service;
using SurvaySystem.DomainProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class KPIController : Controller
    {
        private readonly ITblKPIService _service;

        public KPIController(ITblKPIService service)
        {
            _service = service;
        }

        // GET: KPIController
        public async Task<ActionResult> Index()
        {
          
            var response=await _service.GetAll();
            ViewData["Total"] = response.Data.Select(a => a.TargetValue).Sum();
            return View(response);
        }

        // GET: KPIController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KPIController/Create
        //public async Task<ServiceResponse<bool>> Create(AddTblKPIDTO addTbl)
        //{
        //    #region Guard
        //    if (!ModelState.IsValid)
        //    {
        //        _service.NotValid<bool>(false);
        //    }
        //    #endregion
        //    var response =await _service.AddTBlKPI(addTbl);
        //    return response;
        //}

        //public async Task<GetTblKPIDTO> Create(AddTblKPIDTO addTbl)
        //{
        //    #region Guard
        //    if (!ModelState.IsValid)
        //    {
        //        _service.NotValid<int>(-1);
        //    }
        //    #endregion
        //    ViewData["Total"] = 20;

        //    var response = await _service.AddTBlKPI(addTbl);
        //    return response.Data;
        //    return new GetTblKPIDTO() { DepartmentId = 2, Description = "yass", Id = response.Data, MeasureUnit = false, TargetValue = 10000 };
        //}
        // GET: KPIController/UpdateData/5
        //public async Task<string> UpdateDataAsync(UpdateTblKPIDTO updateTblKPIDTO)
        //{
        //    #region Guard
        //    if (!ModelState.IsValid)
        //    {
        //        return _service.NotValid<string>(null).Message;
                 
        //    }
        //    #endregion
        //    ViewData["Total"] = 20;

        //    var response = await _service.UpdateTBlKPI(updateTblKPIDTO);
        //    return response.Success?updateTblKPIDTO.Value :response.Message;
        //}

        // POST: KPIController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KPIController/Delete/5
        //public async Task<string> Delete(int id)
        //{
        //    var respons=await _service.DeleteTBlKPI(id);
        //    //return respons;
        //    return respons.Success ?"ok":"error";
        //}

        // POST: KPIController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
