using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class EmailVM
    {
        public int ID { get; set; }
        [StringLength(255)]
        [Display(Name = "From Email")]
        public string FromEmail { get; set; }
        [StringLength(255)]
        [Display(Name = "To Email")]
        public string ToEmail { get; set; }
        [Display(Name = "Email to Group")]
        public string EmailToGroup { get; set; }
        [Display(Name = "Users")]
        public string Users { get; set; }
        [Display(Name = "Users Area")]
        public string UsersArea { get; set; }
        [Display(Name = "Venue")]
        public string Venue { get; set; }
        [Display(Name = "Venue Type")]
        public string VenueType { get; set; }
        [StringLength(512)]
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string Sendby { get; set; } //Send by = UserID(Created_By) of current user
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
