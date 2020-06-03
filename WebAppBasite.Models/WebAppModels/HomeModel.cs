using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.Models.WebAppModels
{
    public class HomeModel
    {
        public List<News> TopNews { set; get; }
        public List<News> TopNewsByCate { set; get; }

        public List<Images> ImageGallery { set; get; }

        public List<Images> BannerImage { set; get; }

        public List<Images> FeedbackNumber { set; get; }

        public List<Images> VideoHome { set; get; }

        public List<Contacts> InfoContact { set; get; }

        public List<DanhMucChung> getMenu { set; get; }
        public List<DanhMucChung> listCatetop { set; get; }

        public News DetailNews { set; get; }
        public List<News> RelatedNews { set; get; }
        public List<DanhMucChung> AlbumList { get; set; }
        public List<DanhMucChung> VideoList { get; set; }

        public List<Tags> listTag { set; get; }

        public List<News> ListTopHot { set; get; }
        public List<Comments> ListComment { set; get; }

        public List<Tags> listtagbyId { set; get; }
    }
}