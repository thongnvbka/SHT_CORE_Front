using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Models.ViewModel;

namespace WebAppBasite.Controllers.Components
{
    public class BannerHomeViewComponent : ViewComponent
    {
        private ImagesDAL dal = new ImagesDAL("Images");
        private HomeViewModels homeViewModels = new HomeViewModels();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            homeViewModels.BannerImage = await dal.GetSlide();
            return View(homeViewModels);
        }
    }
}
