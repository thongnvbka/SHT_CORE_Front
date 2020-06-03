using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Models.ViewModel;

namespace WebAppBasite.Controllers.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private DanhMucChungDAL dmDAL = new DanhMucChungDAL("DanhMucChung");
        private ContactDAL ctDAL = new ContactDAL("Contact");
        private HomeViewModels homeViewModels = new HomeViewModels();
        [ResponseCache(CacheProfileName = "Component")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            homeViewModels.getMenu = await dmDAL.GetDanhMucChung();
            homeViewModels.InfoContact = await ctDAL.GetAllList();
            return View(homeViewModels);
        }
    }
}
