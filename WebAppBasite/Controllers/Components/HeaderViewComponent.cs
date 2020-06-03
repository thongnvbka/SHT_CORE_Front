using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Models.ViewModel;

namespace WebAppBasite.Controllers.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private DanhMucChungDAL dmDAL = new DanhMucChungDAL("DanhMucChung");
        private ContactDAL ctDAL = new ContactDAL("Contact");
        private HomeViewModels homeViewModels = new HomeViewModels();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            homeViewModels.getMenu = await dmDAL.GetDanhMucChung();
            homeViewModels.InfoContact = await ctDAL.GetAllList();
            return View(homeViewModels);
        }
    }
}