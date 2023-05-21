using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class SRECoordinatorVM
    {
        public int ID { get; set; }
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Nm { get; set; }
        [StringLength(35)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(35)]
        public string LastName { get; set; }

        [Display(Name = "SRE Coordinator Rep")]
        public int? SRECoordinatorRepID { get; set; }
        [Display(Name = "SRE Coordinator Rep")]
        public string SRECoordinatorRepName { get; set; }
        [Display(Name = "Postal Address")]
        [StringLength(50)]
        public string PostalAddress { get; set; }
        [Display(Name = "Suburb")]
        public int? PASuburbID { get; set; }
        [Display(Name = "Suburb")]
        public string PASuburbName { get; set; }
        [Display(Name = "Landline")]
        [StringLength(20)]
        public string Phone1 { get; set; }
        [Display(Name = "Mobile")]
        [StringLength(20)]
        public string Phone2 { get; set; }
        [Display(Name = "E-mail")]
        [StringLength(100)]
        public string email { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Notes")]
        public string Note { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
