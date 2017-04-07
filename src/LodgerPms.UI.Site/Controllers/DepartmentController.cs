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
    public class DepartmentController : BaseController
    {
        private readonly IDeparmentAppService _departmentAppService;
        private readonly IDepartmentGroupAppService _departmentGroupAppService;

        public DepartmentController(IDeparmentAppService DepartmentAppService, 
            IDomainNotificationHandler<DomainNotification> notifications,
             IDepartmentGroupAppService departmentGroupAppService) 
            : base(notifications)
        {
            _departmentAppService = DepartmentAppService;
            _departmentGroupAppService = departmentGroupAppService;
        }


        #region Department

        [HttpGet]
        [AllowAnonymous]
        [Route("Department-management/list-all")]
        public IActionResult Index()
        {

            var model = new DepartmentListModel();
            var g = _departmentGroupAppService.GetAll().Select(x => new SelectListItem { Value = x.Id, Text=x.Description });
            model.DepartmentGroups = g.ToList();
            model.Departments = _departmentAppService.GetAll().ToList();

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Department-management/list-all")]
        public IActionResult Index(string searchString, string DepartmentType)
        {
            var departments = _departmentAppService.GetAll();
           

            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(d => d.Description.Contains(searchString));
            }

            return View(departments.ToList());
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

            var DepartmentViewModel = _departmentAppService.GetById(id);

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
            var groups = _departmentGroupAppService.GetAll()
                .Select(x=> new SelectListItem {
                    Value= x.Id,
                    Text =  x.Description
                }).ToList();

            var model = new DepartmentViewModel();
            model.DepartmentGroups = groups;
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var g = _departmentGroupAppService.FindById(model.DepartmentGroupId);
            model.DepartmentGroup = g;
            _departmentAppService.Register(model);

            if (IsValidOperation())
                ViewBag.Sucesso = "Department Registered!";

            var groups = _departmentGroupAppService.GetAll()
               .Select(x => new SelectListItem
               {
                   Value = x.Id,
                   Text = x.Description
               }).ToList();


            model.DepartmentGroups = groups;

            return View(model);
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

            var DepartmentViewModel = _departmentAppService.GetById(id);

            if (DepartmentViewModel == null)
            {
                return NotFound();
            }
            var groups = _departmentGroupAppService.GetAll()
             .Select(x => new SelectListItem
             {
                 Value = x.Id,
                 Text = x.Description
             }).ToList();
            DepartmentViewModel.DepartmentGroups = groups;
            return View(DepartmentViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDepartmentData")]
        [Route("Department-management/edit-Department/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel DepartmentViewModel)
        {
            if (!ModelState.IsValid) return View(DepartmentViewModel);

            _departmentAppService.Update(DepartmentViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Department Updated!";

            var groups = _departmentGroupAppService.GetAll()
            .Select(x => new SelectListItem
            {
                Value = x.Id,
                Text = x.Description
            }).ToList();
            DepartmentViewModel.DepartmentGroups = groups;

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

            var DepartmentViewModel = _departmentAppService.GetById(id);

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
            _departmentAppService.Remove(id);

            if (!IsValidOperation()) return View(_departmentAppService.GetById(id));

            ViewBag.Sucesso = "Department Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("Department-management/Department-history/{id:guid}")]
        public JsonResult History(string  id=null)
        {
            var DepartmentHistoryData = _departmentAppService.GetAllHistory(id);
            return Json(DepartmentHistoryData);
        }


        #endregion

       
    }
}
