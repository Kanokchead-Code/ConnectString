using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectString.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectString.Controllers
{
    public class PatientsController : Controller
    {
        public IActionResult Index()
        {
            PatientContext context = HttpContext.RequestServices.GetService(typeof(ConnectString.Models.PatientContext))
                as PatientContext; 
            return View(context.GetAllPatient());
        }


    }
}