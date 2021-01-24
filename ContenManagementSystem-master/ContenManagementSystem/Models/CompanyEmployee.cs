using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class CompanyEmployee
    {
        public int CompanyEmployeeID { get; set; }
        public string empName { get; set; }

        public string position { get; set; }

        public string pictureID { get; set; }
    }
}