using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class UserAuditVM
    {
        [Display(Name = "User Audit ID")]
        public int UserAuditId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Timestamp")]

        public DateTimeOffset Timestamp { get; set; } = DateTime.UtcNow;
        [Display(Name = "Audit Event")]

        public UserAuditEventType AuditEvent { get; set; }
        [Display(Name = "IP Address")]

        public string IpAddress { get; set; }

    }
}
