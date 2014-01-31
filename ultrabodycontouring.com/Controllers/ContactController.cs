using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
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
				string smtpHost = "smtp.sendgrid.net";
				string smtpUser = "azure_41b0c2c8fd0de372ebef67afb37f62c1@azure.com";
				string smtpPass = "whump7e7";
				string destEmail = "sharon@ultrabodycontouring.com";
				string emailSubj = "Website Contact";

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
