using System;
using LodgerPms.Application.Interfaces;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LodgerPms.Application.Interfaces.Departments;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data;
using System.Linq;
using LodgerPms.Application.Services.Departments;
using Microsoft.AspNetCore.Mvc.Rendering;
using LodgerPms.UI.Site.ViewModel;

namespace LodgerPms.UI.Site.Controllers
{
    [Authorize]
    public class DepartmentGroupController : BaseController
    {
        private readonly IDeparmentAppService _departmentAppService;
        private readonly IDepartmentGroupAppService _departmentGroupAppService;

        public DepartmentGroupController(IDeparmentAppService DepartmentAppService, 
            IDomainNotificationHandler<DomainNotification> notifications,
             IDepartmentGroupAppService departmentGroupAppService) 
            : base(notifications)
        {
            _departmentAppService = DepartmentAppService;
            _departmentGroupAppService = departmentGroupAppService;
        } 

        #region Department Group

        [HttpGet]
        [AllowAnonymous]
        [Route("Department-group-management/list-all")]
        public IActionResult Index()
        {
            return View(_departmentGroupAppService.GetAll());
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Department-group-management/list-all")]
        public IActionResult Index(string searchString)
        {
            var departments = _departmentGroupAppService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(d => d.Description.Contains(searchString));
            }

            return View(departments.ToList());
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Department-management/Department-group-details/{id:guid}")]
        public IActionResult Details(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DepartmentViewModel = _departmentGroupAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }

            return View(DepartmentViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/group-register-new")]
        public IActionResult  Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/group-register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult  Create(DepartmentGroupViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _departmentGroupAppService.Register(model);

            if (IsValidOperation())
                ViewBag.Sucesso = "Department Registered!";

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/group-edit-Department/{id:guid}")]
        public IActionResult  Edit(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DepartmentViewModel = _departmentGroupAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }

            return View(DepartmentViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/group-edit-Department/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult  Edit(DepartmentGroupViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _departmentGroupAppService.Update(model);

            if (IsValidOperation())
                ViewBag.Sucesso = "Department Updated!";

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveDepartmentData")]
        [Route("Department-management/group-remove-Department/{id:guid}")]
        public IActionResult  Delete(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DepartmentViewModel = _departmentGroupAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }

            return View(DepartmentViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveDepartmentData")]
        [Route("Department-management/group-remove-Department/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult  DeleteConfirmed(string id = null)
        {
            _departmentGroupAppService.Remove(id);

            if (!IsValidOperation()) return View(_departmentGroupAppService.GetById(id));

            ViewBag.Sucesso = "Department Group Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("Department-management/group-Department-history/{id:guid}")]
        public JsonResult  History(string id = null)
        {
            var DepartmentHistoryData = _departmentGroupAppService.GetAllHistory(id);
            return Json(DepartmentHistoryData);
        }


        #endregion
    }
}
