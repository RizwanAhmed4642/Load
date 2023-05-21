using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
		Task SendOTPEmailAsync(string toEmail, string htmlString, out string fromEmail, string subject = "OTP for Verification", List<string> attachmentPaths = null);
    }
}
