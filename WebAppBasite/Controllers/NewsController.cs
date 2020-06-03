using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppBasite.Common;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Models.NewsViewModels;
using WebAppBasite.Models.ProjectModels;
using WebAppBasite.Models.ViewModel;
using WebAppBasite.Ultilities;

namespace WebAppBasite.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger _logger;
        private NewsDAL newDAL = new NewsDAL("News");
        private TagsDAL tagDAL = new TagsDAL("Tags");
        private HomeViewModels homeViewModels = new HomeViewModels();
        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[Route("{cate_slug}.html")]
        //[ResponseCache(CacheProfileName = "Default")]
        //public async Task<IActionResult> NewstCategory(string cate_slug, int? pageSize, int page = 1)
        //{
        //    if (pageSize == null)
        //        pageSize = Ultilities.Common.GetByKey("pageSize").MapInt();
        //    //ViewBag.DanhMuc = HomeService.Instance.DanhMucbySlug(cate_slug);
        //    var catalog = new NewsCategoriesViewModels();
        //    catalog.PageSize = pageSize;
        //    catalog.Data = await newDAL.GetListNewsbyCates(cate_slug, page, pageSize.MapInt());

        //    if (catalog.Data.Results == null || catalog.Data.Results.Count == 0)
        //        return RedirectToAction("NotFound", "Common");
        //    else
        //        return View(catalog);
        //}
        // danh sachs tag
        [Route("Tag/{tag_slug}.html")]
        public async Task<IActionResult> NewsTag(string tag_slug, int? pageSize, int page = 1)
        {
            if (pageSize == null)
                pageSize = Ultilities.Common.GetByKey("pageSize").MapInt();
            //ViewBag.DanhMuc = HomeService.Instance.DanhMucbySlug(cate_slug);
            var tag = new NewsCategoriesViewModels();
            tag.PageSize = pageSize;
            tag.Data = await newDAL.GetListNewsbyTag(tag_slug, page, pageSize.MapInt());
            ViewBag.tagLug = tag_slug;
            return View(tag);
        }
        //[Route("{cate_slug}/{slug}.html")]
        //public async Task<IActionResult> Details(string cate_slug = "", string slug = "")
        //{
        //    ViewBag.RelatedNews = await newDAL.GetlistRelatedNews(cate_slug, slug);

        //    homeViewModels.DetailNews = await newDAL.GetNewsdetail(cate_slug, slug);
        //    if (homeViewModels.DetailNews == null || homeViewModels.DetailNews.Id == 0)
        //    {
        //        string url = Ultilities.Common.GetByKey("domain_fontend") + cate_slug + "/" + slug + ".html";
        //        if (Ultilities.Common.GetByKey("AllowSendmail") == "1")
        //        {
        //            MailHelper.SendMail(Ultilities.Common.GetByKey("Mailreceived"), "Sao Hà Thành", "Đường dẫn " + url + " không hợp lệ! Vui lòng kiểm tra lại");
        //        }
        //        return RedirectToAction("NotFound", "Common");
        //    }
        //    // home.DetailNews = home.DetailNews ?? new News();
        //    // home.ListComment = CommentsService.Instance.GetComments();
        //    homeViewModels.listtagbyId = await tagDAL.GetTagListbyId(slug);

        //    //model = model ?? new News();

        //    return View(homeViewModels);
        //}
        // Tìm kiếm
      
        public async Task<IActionResult> Search(string keyWord, int? pageSize, int page = 1)
        {
            if (pageSize == null)
                pageSize = Ultilities.Common.GetByKey("pageSize").MapInt();
            ViewBag.Keyword = keyWord;
            var result = new NewsCategoriesViewModels();
            result.PageSize = pageSize;
            result.Data = await newDAL.GetListSearching(keyWord, page, pageSize.MapInt());
            return View(result);
        }

    }
}