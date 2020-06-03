using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Models.ViewModel;

namespace WebAppBasite.Controllers.Components
{
    public class ImageVideoViewComponent : ViewComponent
    {
        private ImagesDAL imgDAL = new ImagesDAL("Images");
        private DanhMucChungDAL dmDAL = new DanhMucChungDAL("DanhMucChung");
        private HomeViewModels homeViewModels = new HomeViewModels();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            homeViewModels.AlbumList = await dmDAL.GetAbumList();
            homeViewModels.VideoList = await dmDAL.GetVideoList();
            homeViewModels.VideoHome = await imgDAL.GetVideoByType();
            return View(homeViewModels);
        }
    }
}

