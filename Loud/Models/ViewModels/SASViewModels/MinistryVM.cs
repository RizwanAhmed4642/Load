using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class MinistryVM
    {
        public int ID { get; set; }
        [Display(Name = "Church")]
        public int? ChurchID { get; set; }
        [Display(Name = "Church")]
        public string ChurchName { get; set; }
        [Display(Name = "Ministry Type")]
        public int? MinistryTypeID { get; set; }
        [Display(Name = "Ministry Type")]
        public string MinistryTypeName { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(35)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Suburb")]
        public int? SASuburbID { get; set; }
        [Display(Name = "Suburb")]
        public string SASuburbName { get; set; }
        [Display(Name = "PA Same as SA")]
        public bool PASameAsSA { get; set; }
        [StringLength(50)]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Display(Name = "PA Town")]
        public int? PASuburbID { get; set; }
        [Display(Name = "PA Town")]
        public string PASuburbName { get; set; }
        [StringLength(20)]
        [Display(Name = "Landline")]
        public string Phone1 { get; set; }
        [StringLength(20)]
        [Display(Name = "Mobile")]
        public string Phone2 { get; set; }
        [StringLength(20)]
        public string Fax { get; set; }
        [StringLength(80)]
        [Display(Name = "E-mail")]
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
