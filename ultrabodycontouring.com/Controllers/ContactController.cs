using System;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Configuration;
using ultrabodycontouring.com.Models;

namespace ultrabodycontouring.com.Controllers
{
	public class ContactController : Controller
	{
		//
		// POST: /Contact

		[HttpPost]
		public ActionResult Index(Contact model)
		{
			try
			{
                string smtpHost = WebConfigurationManager.AppSettings["smtp-host"];
                string smtpUser = WebConfigurationManager.AppSettings["smtp-user"];
                string smtpPass = WebConfigurationManager.AppSettings["smtp-pass"];
                string destEmail = WebConfigurationManager.AppSettings["contact-email"];
                string emailSubj = WebConfigurationManager.AppSettings["contact-subject"];

                var mail = new MailMessage();
				
				mail.From = new MailAddress(model.Email, model.Name);
				mail.To.Add(new MailAddress(destEmail));

				mail.Subject = emailSubj;
				mail.Body = model.Message;

				mail.IsBodyHtml = true;
				mail.Priority = MailPriority.Normal;

				var smtp = new SmtpClient();
				smtp.Host = smtpHost;
				smtp.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);

				smtp.Send(mail);

				return Content("Message has been successfully sent");
			}
			catch (Exception ex)
			{
				return new HttpStatusCodeResult(500, ex.Message);
			}
		}
	}
}
