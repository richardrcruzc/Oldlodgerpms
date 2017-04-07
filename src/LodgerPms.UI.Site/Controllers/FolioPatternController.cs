using System;
using LodgerPms.Application.Interfaces;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data;
using System.Linq;

using Microsoft.AspNetCore.Mvc.Rendering;
using LodgerPms.UI.Site.ViewModel;
using LodgerPms.Application.Interfaces.Departments;

namespace LodgerPms.UI.Site.Controllers
{
    [Authorize]
    public class FolioPatternController : BaseController
    {
        
        private readonly IFolioPatternAppService _folioPatternAppService;

        public FolioPatternController(IFolioPatternAppService folioPatternAppService, 
            IDomainNotificationHandler<DomainNotification> notifications ) 
            : base(notifications)
        {
            _folioPatternAppService = folioPatternAppService; 
        } 

        #region FolioPattern Group

        [HttpGet]
        [AllowAnonymous]
        [Route("FolioPattern-management/list-all")]
        public IActionResult Index()
        {
            return View(_folioPatternAppService.GetAll());
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("FolioPattern-management/list-all")]
        public IActionResult Index(string searchString)
        {
            var FolioPatterns = _folioPatternAppService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                FolioPatterns = FolioPatterns.Where(d => d.Description.Contains(searchString));
            }

            return View(FolioPatterns.ToList());
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("FolioPattern-management/FolioPattern-details/{id:guid}")]
        public IActionResult Details(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FolioPatternViewModel = _folioPatternAppService.GetById(id);

            if (FolioPatternViewModel == null)
            {
                return NotFound();
            }

            return View(FolioPatternViewModel);
        }

        [HttpGet]
     //   [Authorize(Policy = "CanWriteFolioPatternData")]
        [Route("FolioPattern-management/register-new")]
        public IActionResult  Create()
        {
            return View();
        }

        [HttpPost]
      //  [Authorize(Policy = "CanWriteFolioPatternData")]
        [Route("FolioPattern-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult  Create(FolioPatternViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _folioPatternAppService.Register(model);

            if (IsValidOperation())
                ViewBag.Sucesso = "FolioPattern Registered!";

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteFolioPatternData")]
        [Route("FolioPattern-management/edit-FolioPattern/{id:guid}")]
        public IActionResult  Edit(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FolioPatternViewModel = _folioPatternAppService.GetById(id);

            if (FolioPatternViewModel == null)
            {
                return NotFound();
            }

            return View(FolioPatternViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteFolioPatternData")]
        [Route("FolioPattern-management/edit-FolioPattern/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult  Edit(FolioPatternViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _folioPatternAppService.Update(model);

            if (IsValidOperation())
                ViewBag.Sucesso = "FolioPattern Updated!";

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveFolioPatternData")]
        [Route("FolioPattern-management/remove-FolioPattern/{id:guid}")]
        public IActionResult  Delete(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FolioPatternViewModel = _folioPatternAppService.GetById(id);

            if (FolioPatternViewModel == null)
            {
                return NotFound();
            }

            return View(FolioPatternViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveFolioPatternData")]
        [Route("FolioPattern-management/remove-FolioPattern/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult  DeleteConfirmed(string id = null)
        {
            _folioPatternAppService.Remove(id);

            if (!IsValidOperation()) return View(_folioPatternAppService.GetById(id));

            ViewBag.Sucesso = "FolioPattern Group Removed!";
            return RedirectToAction("Index");
        }

        //[AllowAnonymous]
        //[Route("FolioPattern-management/FolioPattern-history/{id:guid}")]
        //public JsonResult  History(string id = null)
        //{
        //    var FolioPatternHistoryData = _folioPatternAppService.GetAllHistory(id);
        //    return Json(FolioPatternHistoryData);
        //}


        #endregion
    }
}
