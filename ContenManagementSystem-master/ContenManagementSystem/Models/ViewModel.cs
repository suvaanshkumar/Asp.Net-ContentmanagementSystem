using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class ViewModel
    {
        public int ViewModelID { get; set; }
        public CompanyDescClass company { get; set; } = new CompanyDescClass();
        public LeftFooterModel lfm { get; set; } = new LeftFooterModel();

        public ViewModel()
        {
            
        }
    }
}