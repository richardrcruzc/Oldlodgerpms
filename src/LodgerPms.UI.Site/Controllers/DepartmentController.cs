using System;
using LodgerPms.Application.Interfaces;
using LodgerPms.Application.ViewModels;
using LodgerPms.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LodgerPms.Application.Interfaces.Departments;
using LodgerPms.Application.ViewModels.Deparments;

namespace LodgerPms.UI.Site.Controllers
{
    [Authorize]
    public class DepartmentController : BaseController
    {
        private readonly IDeparmentAppService _DepartmentAppService;

        public DepartmentController(IDeparmentAppService DepartmentAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _DepartmentAppService = DepartmentAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Department-management/list-all")]
        public IActionResult Index()
        {
            return View(_DepartmentAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Department-management/Department-details/{id:guid}")]
        public IActionResult Details(string id=null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DepartmentViewModel = _DepartmentAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }

            return View(DepartmentViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel DepartmentViewModel)
        {
            if (!ModelState.IsValid) return View(DepartmentViewModel);
            _DepartmentAppService.Register(DepartmentViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Department Registered!";

            return View(DepartmentViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/edit-Department/{id:guid}")]
        public IActionResult Edit(string id=null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DepartmentViewModel = _DepartmentAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }

            return View(DepartmentViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/edit-Department/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel DepartmentViewModel)
        {
            if (!ModelState.IsValid) return View(DepartmentViewModel);

            _DepartmentAppService.Update(DepartmentViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Department Updated!";

            return View(DepartmentViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveDepartmentData")]
        [Route("Department-management/remove-Department/{id:guid}")]
        public IActionResult Delete(string  id=null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DepartmentViewModel = _DepartmentAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }

            return View(DepartmentViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveDepartmentData")]
        [Route("Department-management/remove-Department/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id=null)
        {
            _DepartmentAppService.Remove(id);

            if (!IsValidOperation()) return View(_DepartmentAppService.GetById(id));

            ViewBag.Sucesso = "Department Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("Department-management/Department-history/{id:guid}")]
        public JsonResult History(string  id=null)
        {
            var DepartmentHistoryData = _DepartmentAppService.GetAllHistory(id);
            return Json(DepartmentHistoryData);
        }
    }
}
