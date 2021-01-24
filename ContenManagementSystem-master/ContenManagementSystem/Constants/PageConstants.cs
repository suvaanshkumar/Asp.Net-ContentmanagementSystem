using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Constants
{
    public class PageConstants
    {
        public static Dictionary<int, string> cols = new Dictionary<int, string>() {
            {1,"<div class='col-md-12'></div>" },
            { 2,"<div class='col-md-6'></div>" },
            { 3,"<div class='col-md-4'></div>" },
            { 4,"<div class='col-md-3'></div>" },
            { 6,"<div class='col-md-2'></div>" },
            { 12,"<div class='col-md-1'></div>" }
        };
        public static string rows = "<div class='row'>";
    }
}