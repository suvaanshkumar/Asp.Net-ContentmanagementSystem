using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class LeftFooterModel
    {   
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
    
        public int LeftFooterModelID { get; set; }
        public String para1 { get; set; }
        public String para2 { get; set; }
        
        
        public String videourl { get; set; }

        public int noofLikes { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(100)]
        public String videoDescription { get; set; }

        public LeftFooterModel(int id, string para1, string para2, string videourl, int noofLikes, string videoDescription)
        {
            Id = id;
            this.para1 = para1;
            this.para2 = para2;
            this.videourl = videourl;
            this.noofLikes = noofLikes;
            this.videoDescription = videoDescription;
        }

        public LeftFooterModel()
        {
        }
    }
}