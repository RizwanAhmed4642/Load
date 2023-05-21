using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class GoogleMapPinsVM
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        public string nm { get; set; }
        public float? lat { get; set; }
        public float? lng { get; set; }
        public string venueName { get; set; }
        public string type { get; set; }

        [Display(Name = "Type Aliases")]
        public string TypeAliases { get; set; }

        [Display(Name = "Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Suburb")]
        public string SuburbName { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }

        [Display(Name = "Landline")]
        public string Phone1 { get; set; }

        [Display(Name = "Mobile")]
        public string Phone2 { get; set; }

        [Display(Name = "E-mail 1")]
        public string email { get; set; }

        [Display(Name = "E-mail 2")]
        public string email2 { get; set; }

		[Display(Name = "Area")]
		public int? AreaID { get; set; }
		[Display(Name = "Area")]
		public string AreaName { get; set; }
		[Display(Name = "SRE Status")]
		public int? SREStatusID { get; set; }
		[Display(Name = "SRE Status")]
		public string SREStatusName { get; set; }
		public int Participate { get; set; }
	}
}
