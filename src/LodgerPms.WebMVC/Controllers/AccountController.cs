using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Authentication;
using LodgerPms.WebMVC.Services;
using LodgerPms.WebMVC.ViewModels;

namespace LodgerPms.WebMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {        
            private readonly IIdentityParser<ApplicationUser> _identityParser;
            public AccountController(IIdentityParser<ApplicationUser> identityParser) =>
                _identityParser = identityParser;

            public ActionResult Index() => View();

            [Authorize]
            public IActionResult SignIn(string returnUrl)
            {
                var user = User as ClaimsPrincipal;

                //TODO - Not retrieving AccessToken yet
                var token = user.FindFirst("access_token");
                if (token != null)
                {
                    ViewData["access_token"] = token.Value;
                }

                // "Catalog" because UrlHelper doesn't support nameof() for controllers
                // https://github.com/aspnet/Mvc/issues/5853
                //return RedirectToAction(nameof(CatalogController.Index), "Catalog");

                return RedirectToAction("index");
            }

            public IActionResult Signout()
            {
                HttpContext.Authentication.SignOutAsync("Cookies");
                HttpContext.Authentication.SignOutAsync("oidc");

                // "Catalog" because UrlHelper doesn't support nameof() for controllers
                // https://github.com/aspnet/Mvc/issues/5853
                var homeUrl = "SignIn"; // Url.Action(nameof(CatalogController.Index), "Catalog");
                return new SignOutResult("oidc", new AuthenticationProperties { RedirectUri = homeUrl });
            }
        }
    }
