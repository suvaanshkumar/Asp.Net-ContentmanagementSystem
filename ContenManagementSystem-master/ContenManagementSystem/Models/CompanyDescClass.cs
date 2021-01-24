using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class CompanyDescClass
    {

        public int CompanyDescClassID { get; set; }
        public string ShortDesc { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        public string Telephone { get; set; } //maybe long

        public virtual CompanyOpenHours OpenHours { get; set; }//maybe datatime?  //maybe just a list?

        public virtual ICollection<CompanyEmployee> Employees { get; set; } = new List<CompanyEmployee>();

        

        public void pullData()
        {
            //Later will be recieving parameters and pulling from database
            //For now it generates dummy data

            ShortDesc = "State of the art scamming company, with long proven history of facilitating businesses perferct the art of fraud, our mission is not to only deciet but to do it with style, we religiously practice what we preach on Juhanna.";
            Address = "0 trace street, Toronto";
            Website = "example@wordpress.com";
            Telephone = "(915) 6263-2312";

            OpenHours = new CompanyOpenHours()
            {
                mondayOpen = "0800",
                mondayClose = "1700",
                tuesdayOpen = "0800",
                tuesdayClose = "1700",
                wednesdayOpen = "0800",
                wednesdayClose = "1700",
                thursdayOpen = "0700",
                thursdayClose = "1700",
                fridayOpen = "0800",
                fridayClose = "1700",
                saturdayOpen = "1000",
                saturdayClose = "1400",
                sundayOpen = "1000",
                sundayClose = "1400"

            };

            Employees.Add(new CompanyEmployee() { pictureID = "../images/1.jpg", empName = "Arnold", position = "Big Boss" });
            Employees.Add(new CompanyEmployee() { pictureID = "../images/2.jpg", empName = "Maggie", position = "Cleaner" });
            Employees.Add(new CompanyEmployee() { pictureID = "../images/3.jpg", empName = "Niko", position = "Conflict Resolution" });
            Employees.Add(new CompanyEmployee() { pictureID = "../images/4.jpg", empName = "Borat", position = "Human resauces" });
            Employees.Add(new CompanyEmployee() { pictureID = "../images/5.jpg", empName = "Johanna", position = "Junior Developer" });
        }
    }

    
}