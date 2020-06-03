using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBasite.DAL.ModulesDAL;

namespace WebAppBasite.Controllers.Components
{
    public class ImageServiceViewComponent : ViewComponent
    {
        private ImagesDAL dal = new ImagesDAL("Images");
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await dal.GetSlide();
            return View(result);
        }
    }
}
