using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

namespace ChuyenTinDriveData.Controllers
{
    public class HomeController : Controller
    {
        //public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        //{
        //    var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
        //        AuthorizeAsync(cancellationToken);

        //    if (result.Credential != null)
        //    {
        //        var service = new DriveService(new BaseClientService.Initializer
        //        {
        //            HttpClientInitializer = result.Credential,
        //            ApplicationName = "ASP.NET MVC Sample"
        //        });

        //        // YOUR CODE SHOULD BE HERE..
        //        // SAMPLE CODE:
        //        var list = await service.Files.List().ExecuteAsync(cancellationToken);
        //        ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();
        //        return View();
        //    }
        //    else
        //    {
        //        return new RedirectResult(result.RedirectUri);
        //    }
        //}

        public ActionResult Index(CancellationToken cancellationToken)
        {


            var result = new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken).Result;

            if (result.Credential != null)
            {
                var service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });

                // YOUR CODE SHOULD BE HERE..
                // SAMPLE CODE:
                var list = service.Files.List().ExecuteAsync(cancellationToken).Result;
                ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();
                return View();
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}