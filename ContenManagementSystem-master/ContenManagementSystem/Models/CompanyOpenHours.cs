using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class CompanyOpenHours
    {
        //there was no way to connect a dictionary into an entity framwork or a database easily so this object was a must to get it going
        [Key]
        public int CompanyOpenHoursID { get; set; }

        public string mondayOpen { get; set; }
        public string mondayClose { get; set; }

        public string tuesdayOpen { get; set; }
        public string tuesdayClose { get; set; }

        public string wednesdayOpen { get; set; }
        public string wednesdayClose { get; set; }

        public string thursdayOpen { get; set; }
        public string thursdayClose { get; set; }

        public string fridayOpen { get; set; }
        public string fridayClose { get; set; }

        public string saturdayOpen { get; set; }
        public string saturdayClose { get; set; }

        public string sundayOpen { get; set; }
        public string sundayClose { get; set; }

    }
}