using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Models.ViewModel;

namespace WebAppBasite.Controllers.Components
{
    public class FooterViewComponent :ViewComponent
    {
        private ContactDAL ctDAL = new ContactDAL("Contact");
        private HomeViewModels homeViewModels = new HomeViewModels();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            homeViewModels.InfoContact = await ctDAL.GetAllList();
            return View(homeViewModels);
        }
    }
}
