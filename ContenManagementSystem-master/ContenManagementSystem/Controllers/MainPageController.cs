using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace ContenManagementSystem.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        ViewModel viewModel = new ViewModel() ;         
        Boolean initialized = false;
        //public ActionResult Index()
        //{
        //    if (!initialized)
        //    {
        //      //Suvaansh View
        //        viewModel.lfm.para1 = "Cloud computing is the on-demand availability of computer system resources, especially data storage and computing power, without direct active management by the user. The term is generally used to describe data centers available to many users over the Internet.";
        //        viewModel.lfm.videourl = "youtube.com";
        //        viewModel.lfm.noofLikes = 6;
        //        viewModel.lfm.videoDescription = "Technical Webinar: Developing .NET MVC Websites with Kentico Cloud*";
        //        ViewBag.videodescription = viewModel.lfm.videoDescription;
        //        ViewBag.para1 = viewModel.lfm.para1;
        //        ViewBag.nooflikes = viewModel.lfm.noofLikes;

        //    //Rashed View
        //        viewModel.company.pullData();
        //        initialized = true;

        //    //Kanishka View
        //        ViewData["innerHtml"] = "<div id =\"div1\">" +
        //        "<div class='container'><div class='row'><div class='col-md-6'><p>This part is handled by bootstrap</p></div>" +
        //        "<div class='col-md-6'><p>Section divided into 2 parts</p></div></div></div></div>";
        //    }

        //    return View("Main", viewModel);
        //}

        public ActionResult Index()
        {
            
            return View("Main");
        }
    }
}