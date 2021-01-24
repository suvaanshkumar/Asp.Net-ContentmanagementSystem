using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Models
{
    public class Page
    {
        public string PageId { get; set; }
        public string PageHTML { get; set; }
    }
    public class PageStructure
    {
        public string pageName { get; set; }
        public string numberOfSections { get; set; }
        public string numberOfDivisions { get; set; }
    }
    public class PageManagerView
    {
        public IEnumerable<SelectListItem> pages { get; set; }
        public List<string> sections { get; set; }
        public List<string> divisions { get; set; }

        //public string PageId { get; set; }
        //public string SectionId { get; set; }
        //public string NumberOfDivisions { get; set; }
        //public string DivisionId { get; set; }
        //public string Sectiontext { get; set; }
    }
    public class PageSettings
    {
        [Required]
        public string pageName { get; set; }
        [Required]
        public List<SetionSettings> sections { get; set; }
    }

    public class SetionSettings
    {
        [Required]
        public string sectionNumber { get; set; }
        [Required]
        public List<DivisionSettings> divs { get; set; }
    }

    public class DivisionSettings
    {
        [Required]
        public string divnumber { get; set; }
        [Required]
        public string divtype { get; set; }
        [Required]
        public string divData { get; set; }
    }
}