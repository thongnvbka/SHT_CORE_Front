using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppBasite.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}