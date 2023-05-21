using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class TaskTypeVM
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        [StringLength(30)]
        public string Nm { get; set; }
        public bool ResponseRequired { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
