using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class ChaplainVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Name of School")]
        public string Nm { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Notes")]
        public string Note { get; set; }
        [StringLength(35)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(35)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Display(Name = "Suburb")]
        public int? PASuburbID { get; set; }
        public string SuburbName { get; set; }
        [StringLength(20)]
        [Display(Name = "Landline")]
        public string Phone1 { get; set; }
        [StringLength(20)]
        [Display(Name = "Mobile")]
        public string Phone2 { get; set; }
        [StringLength(100)]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
