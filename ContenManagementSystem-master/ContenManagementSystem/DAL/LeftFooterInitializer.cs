using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.DAL
{
    public class LeftFooterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LeftFooterContext>
    {
        protected override void Seed(LeftFooterContext context)
        {
            context.leftFooterModel.Add(new LeftFooterModel(1, "Tutorials Point originated from the idea that there exists a class of readers who respond better to online content and prefer to learn new skills at their own pace from the comforts of their drawing rooms.The journey com", "there is a way", "youtube.com", 6, "Technical Webinar: Developing .NET MVC Websites with Kentico Cloud*"));
            context.feedBackPages.Add(new feedBackPage(1, "suvaanshkumar@gmail.com", "very good", 9, "About feedback"));
            context.SaveChanges();
        }
    }
}