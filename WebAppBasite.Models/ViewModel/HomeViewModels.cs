using System;
using System.Collections.Generic;
using System.Text;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.Models.ViewModel
{
   public class HomeViewModels
    {
        public List<News> TopNews { set; get; }
        public IEnumerable<News> TopNewsByCate { set; get; }

        public IEnumerable<Images> ImageGallery { set; get; }
      
         public IEnumerable<Images> ImgService { set; get; }
        public IEnumerable<Images> BannerImage { set; get; }

        public IEnumerable<Images> FeedbackNumber { set; get; }

        public IEnumerable<Images> VideoHome { set; get; }

        public IEnumerable<Contacts> InfoContact { set; get; }

        public IEnumerable<DanhMucChung> getMenu { set; get; }
        public IEnumerable<DanhMucChung> listCatetop { set; get; }

        public News DetailNews { set; get; }
        public List<News> RelatedNews { set; get; }
        public IEnumerable<DanhMucChung> AlbumList { get; set; }
        public IEnumerable<DanhMucChung> VideoList { get; set; }

        public IEnumerable<Tags> listTag { set; get; }

        public IEnumerable<News> ListTopHot { set; get; }
        public IEnumerable<Comments> ListComment { set; get; }

        public IEnumerable<Tags> listtagbyId { set; get; }
    }
}
