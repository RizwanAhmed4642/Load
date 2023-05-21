using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using System.Linq;
using MimeKit;

namespace SAS.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        //Using example
        //EmailsHandler.SendEmail("atifbasharat98@gmail.com", "Hello I am Otp 119922");
        private static string fromEmailOTP = "otp@logic-consultants.com";
        private static string emailPassOTP = "9Logic0*@123";

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendOTPEmailAsync(string toEmail, string htmlString, out string fromEmail, string subject = "OTP for Verification", List<string> attachmentPaths = null)
        {
            try
            {
                MailMessage message = new MailMessage();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                message.From = new MailAddress(fromEmailOTP);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                //Attach files to email
                if (attachmentPaths != null && attachmentPaths.Count > 0)
                {
                    foreach (var attachmentPath in attachmentPaths)
                    {
                        var attachment = new Attachment(attachmentPath);
                        message.Attachments.Add(attachment);
                    }
                }
                smtp.Port = 587;
                //smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.Host = "mail.logic-consultants.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(fromEmailOTP, emailPassOTP);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                fromEmail = fromEmailOTP;
                return Task.FromResult("Email is sent successfully!");
            }
            catch (System.Exception exe)
            {
                fromEmail = exe.Message;
                return Task.FromResult(exe.Message);
            }
        }

        //public Task SendOTPEmailWithAttachmentsAsync(string toEmail, string htmlString, out string fromEmail, string subject = "OTP for Verification", List<string> attachmentPaths = null)
        //{
        //    try
        //    {
        //        MailMessage message = new MailMessage();
        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //        message.From = new MailAddress(fromEmailOTP);
        //        message.To.Add(new MailAddress(toEmail));
        //        message.Subject = subject;
        //        message.IsBodyHtml = true; //to make message body as html  
        //        message.Body = htmlString;

        //        Attach files to email
        //        if (attachmentPaths != null && attachmentPaths.Count > 0)
        //        {
        //            foreach (var attachmentPath in attachmentPaths)
        //            {
        //                var attachment = new Attachment(attachmentPath);
        //                message.Attachments.Add(attachment);
        //            }
        //        }

        //        smtp.Port = 587;
        //        smtp.Host = "mail.logic-consultants.com";
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new System.Net.NetworkCredential(fromEmailOTP, emailPassOTP);
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.Send(message);
        //        fromEmail = fromEmailOTP;
        //        return Task.FromResult("Email is sent successfully!");
        //    }
        //    catch (System.Exception exe)
        //    {
        //        fromEmail = exe.Message;
        //        return Task.FromResult(exe.Message);
        //    }
        //}


        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
