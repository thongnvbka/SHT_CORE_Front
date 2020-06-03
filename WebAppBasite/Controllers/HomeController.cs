using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppBasite.DAL.ModulesDAL;
using WebAppBasite.Common.Lib;
using WebAppBasite.Models;
using WebAppBasite.Models.ViewModel;

namespace WebAppBasite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private NewsDAL newDAL = new NewsDAL("News");
        private DanhMucChungDAL dmDAL = new DanhMucChungDAL("DanhMucChung");
        private ImagesDAL imgDAL = new ImagesDAL("Images");
        private ContactDAL ctDAL = new ContactDAL("Contact");
        private HomeViewModels homeViewModels = new HomeViewModels();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       // [ResponseCache(CacheProfileName = "Component")]
        public async  Task<IActionResult>  Index()
        {
            try
            {
                homeViewModels.TopNewsByCate = await newDAL.GetListByCate();
                homeViewModels.listCatetop = await dmDAL.GetListcateNews();
                homeViewModels.ImageGallery = await imgDAL.GetImageServiceByType(3);
                homeViewModels.FeedbackNumber = await imgDAL.GetImageServiceByType(4);
                homeViewModels.InfoContact = await ctDAL.GetAllList();
                homeViewModels.ListTopHot = await newDAL.GetListTophot(5);
                homeViewModels.ImgService = await imgDAL.GetImageService();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message.ToString());
            }


            return View(homeViewModels);
        }
        [Route("gioi-thieu.html")]
        public async Task<IActionResult> About()
        {
            homeViewModels.ListTopHot = await newDAL.GetListTophot(5);
            return View();
        }
        [Route("tam-su-khach-hang.html")]
        public async Task<IActionResult> Confide()
        {
            homeViewModels.ListTopHot = await newDAL.GetListTophot(5);
            return View();
        }
        [Route("dich-vu.html")]
        public async Task<IActionResult> Questions()
        {
            homeViewModels.ListTopHot = await newDAL.GetListTophot(5);
            return View();
        }
        //[Route("danh-sach-video.html")]
        //public async Task<IActionResult> ListVideo()
        //{
        //    homeViewModels.ListTopHot = await newDAL.GetListTophot(5);
        //    return View();
        //}
        [Route("lien-he.html")]
        public async Task<IActionResult> Contact()
        {
            homeViewModels.ListTopHot = await newDAL.GetListTophot(5);
            return View();
        }
        public async Task<IActionResult> GetImgbyAlbumIdAsync(int id)
        {
            try
            {
                var listImg =await imgDAL.GetImgbyAlbumId(id);
                //for (int i = 0; i < listImg.; i++)
                //{
                //    listImg[i].thumb = SUtility.GetThumbNailImg(listImg[i].main_content, "220x150");
                //}
                foreach (var item in listImg)
                {
                    item.thumb = SUtility.GetThumbNailImg(item.main_content, "220x150");
                }
                var JSONresult = Newtonsoft.Json.JsonConvert.SerializeObject(listImg);
                return new ObjectResult(JSONresult);
            } 
            catch (Exception ex)
            {
                throw;
            }
        }


      //  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Partial
        //public Task<PartialViewResult> GetMenu()
        //{
        //    //home.getMenu = HomeService.Instance.GetDanhMucchung();

        //    homeViewModels.InfoContact =await ctDAL.GetAllList();
        //    return PartialView("~/Views/Shared/royalspa/_MainMenu.cshtml", homeViewModels);
        //}
        #endregion
        public JsonResult VerifyGoogleCaptcha(string input = "")
        {
            var stt = false;
            var msg = "";
            try
            {
                var url = "https://www.google.com/recaptcha/api/siteverify";
                var key = "6LdTcLwUAAAAAMMgrjUQ7WwafCeHIYRLzTJgNfT9";
                var data = $"secret={key}&response={input.Trim()}";
                using (var h = new Common.WebLibs.WebLibs.HttpRequest())
                {
                    var html = h.Post(data, url);
                    if (html.Contains("true")) stt = true;
                }
            }
            catch { }
            return Json(new
            {
                status = stt,
                message = msg
            });
        }

        public JsonResult SubmitReservation(string ho_ten = "", string sdt = "", string service = "")
        {
            CustomersDAL cus = new CustomersDAL("Customers");
            var stt = false;
            var msg = "";
            try
            {
                var CreatedAt = Clibs.DatetimeToTimestamp(DateTime.Now);
                cus.InsertCustomer(ho_ten, sdt, service, CreatedAt);
                //https://www.google.com/recaptcha/api/siteverify
                /* {
                      "success": true|false,
                      "challenge_ts": timestamp,  // timestamp of the challenge load (ISO format yyyy-MM-dd'T'HH:mm:ssZZ)
                      "hostname": string,         // the hostname of the site where the reCAPTCHA was solved
                      "error-codes": [...]        // optional
                    }
                 */
                stt = true;
                msg = "Đăng ký thành công!";
            }
            catch (Exception ex)
            {
                stt = false;
                msg = ex.Message;
                // var e = ex.Message;
            }

            return Json(new
            {
                status = stt,
                message = msg
            });
        }
    }
}
