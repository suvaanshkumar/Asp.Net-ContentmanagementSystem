using ContenManagementSystem.Constants;
using ContenManagementSystem.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Controllers
{
    //[Authorize]
    public class PageController : Controller
    {
        // Get page and render based on the url parameter.
        public ActionResult Index()
        {
            string pageId = Convert.ToString(Url.RequestContext.RouteData.Values["id"]);
            if (pageId != "")
            {
                ViewData["innerHtml"] = getDataByPageID(pageId);
            }
            else
            {
                ViewData["innerHtml"] = "";
            }
            return View("DynamicPage");
        }

        public ActionResult PageManager()
        {
            PageManagerView pv = new PageManagerView();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                //var pages = dbContext.PageStructures.Select(p => new SelectListItem {Value=p.pageName,Text=p.pageName });
                //pv.pages = new SelectList(pages, "Value", "Text");
                return View("DynamicPageManager");
            }
        }
        
        //Allow only admins to render the page creator page so that they will be able to create new pages but let the pages be viewed by everyone
        [Authorize(Roles= "Admin")]
        public ActionResult PageCreator()
        {
            return View("PageCreator");
        }

        [HttpPost]
        public ActionResult savePageSettings(PageManagerView pageManagerView)
        {
            //string s = markupCreator(pageManagerView);

            var doc = new HtmlDocument();
            //doc.LoadHtml(s);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[1]");
            //HtmlNode selectedNode = htmlBody.SelectSingleNode("//div[" + pageManagerView.SectionId + "]/div[" + pageManagerView.DivisionId + "]");
            //selectedNode.AppendChild(HtmlNode.CreateNode("<p>"+pageManagerView.Sectiontext+"</p>"));
            ViewData["innerHtml"] = "<div id =\"div1\"><div class='container'>" + htmlBody.OuterHtml + "</div></div>";
            ApplicationDbContext context = new ApplicationDbContext();
            var page = context.Pages.Where(p => p.PageId == "test").FirstOrDefault();
            if(page!= null)
            {
                page.PageHTML = Convert.ToString(ViewData["innerHtml"]);
                context.SaveChanges();
            }
            //context.Pages.Add(new Page() {PageId = "test", PageHTML = Convert.ToString(ViewData["innerHtml"]) });
            //context.SaveChangesAsync();
            //ViewData["innerHTML"] = getDataByPageID("test");
            //return View("DynamicPage",ViewData);
            return RedirectToAction("Index", "Page", new { id ="test"});
        }

        private string getDataByPageID(string pageId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Pages.Where(p => p.PageId == pageId).Select(p => p.PageHTML).FirstOrDefault();
        }

        
        //Save the details of the page and in the process create the html based on the model sent from the client
        [HttpPost]
        public ActionResult saveNewPage(PageSettings model)
        {
            if (!ModelState.IsValid) {
                List<string> errors = new List<string>();
                foreach (var item in ModelState.Values)
                {
                    for (int i = 0; i < item.Errors.Count; i++)
                    {
                        errors.Add(item.Errors[i].ErrorMessage);
                    }
                }
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                HttpContext.Response.StatusDescription = JsonConvert.SerializeObject(errors);
                return Json(new { result = "Failure", errors = errors });
            }

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var duplicatePage = dbContext.Pages.Where(p=>p.PageId==model.pageName).FirstOrDefault();
                if(duplicatePage != null)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    HttpContext.Response.StatusDescription = JsonConvert.SerializeObject(new List<string> { "Page with the same name already exists."});
                    return Json(new { result = "Failure" });
                }
            }

            string s = "<div class='container'>";
            for (int i = 0; i < model.sections.Count; i++)
            {
                s += PageConstants.rows;
                for (int j = 0; j < model.sections[i].divs.Count; j++)
                {
                    s += PageConstants.cols[model.sections[i].divs.Count];
                }
                s += "</div>";
            }
            s += "</div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(s);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[1]");
            for (int i = 0; i < model.sections.Count; i++)
            {
                for (int j = 0; j < model.sections[i].divs.Count; j++)
                {
                    int xpath_i = i + 1;
                    int xpath_j = j + 1;
                    HtmlNode selectedNode = doc.DocumentNode.SelectSingleNode("//div[1]/div[" + xpath_i + "]/div[" + xpath_j + "]");
                    switch (model.sections[i].divs[j].divtype)
                    {
                        case "text/html":
                            selectedNode.AppendChild(HtmlNode.CreateNode("<p>" + model.sections[i].divs[j].divData + "</p>"));
                            break;
                        case "image":
                            selectedNode.AppendChild(HtmlNode.CreateNode("<img src='" + model.sections[i].divs[j].divData + "'/>"));
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            string htmlFinal = "<div id =\"div1\"><div class='container'>" + htmlBody.OuterHtml + "</div></div>";

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Pages.Add(new Page { PageId = model.pageName, PageHTML = htmlFinal });
                dbContext.SaveChanges();
            }
            return Json(new { result = "Success" });
        }
    }   
}