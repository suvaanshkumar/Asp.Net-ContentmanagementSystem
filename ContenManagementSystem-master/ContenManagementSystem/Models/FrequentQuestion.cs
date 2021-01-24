using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class FrequentQuestion
    {
        public int FrequentQuestionID { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string Category { get; set; }
    }
}