using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectString.Models;

namespace ConnectString.Controllers
{
    public class PictureController : Controller
    {
        public IActionResult Index()
        {
            PictureContext context = HttpContext.RequestServices.GetService(typeof(ConnectString.Models.PictureContext))
                as PictureContext;
            return View(context.GetAllPicture());

        }

        public IActionResult Detail()
        {

            return View();
        }
    }
}