using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Controllers

{
    public class LeftFooterController : Controller
    {
        // GET: LeftFooter
        [ActionName("LeftFooterView")]
        public ActionResult Index()
        {
            LeftFooterModel lfm = new LeftFooterModel(1, "Hi i am suvvansh", "there is a way", "youtube.com", 6, "yes thats youtube");
            lfm.para1 = "Cloud computing is the on-demand availability of computer system resources, especially data storage and computing power, without direct active management by the user. The term is generally used to describe data centers available to many users over the Internet.";
            lfm.videourl = "https://www.youtube.com/embed/9dae0R3pkEo?autoplay=1&fs=1&iv_load_policy=1&showinfo=1&rel=1&cc_load_policy=1&start=0&end=0&origin=https://youtubeembedcode.com";
            lfm.noofLikes = 6;
            lfm.videoDescription = "Technical Webinar: Developing .NET MVC Websites with Kentico Cloud*";
            ViewBag.videodescription = lfm.videoDescription;
            ViewBag.para1 = lfm.para1;
            ViewBag.nooflikes = lfm.noofLikes;

            return View();
        }
        [HttpGet]
        public ActionResult edit() {

            return View();
        } 

    }
}