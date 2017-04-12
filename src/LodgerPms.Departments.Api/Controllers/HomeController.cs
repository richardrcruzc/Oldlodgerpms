﻿
using Microsoft.AspNetCore.Mvc;

namespace LodgerPms.Departments.Api.Controllers
{

    // For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

    namespace Microsoft.eShopOnContainers.Services.Catalog.API.Controllers
    {
        public class HomeController : Controller
        {
            // GET: /<controller>/
            public IActionResult Index()
            {
                return new RedirectResult("~/swagger/ui");
            }
        }
    }


}
