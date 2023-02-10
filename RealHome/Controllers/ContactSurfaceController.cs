using RealHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace RealHome.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult RenderForm()
        {
            return PartialView("~/Views/Partials/_Contactform.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = Services.ContentService
                .Create(String.Format("{0}-{1}", model.Name, DateTime.Now.ToString()),
                CurrentPage.Id, "contactFormContent");
                message.SetValue("username", model.Name);
                message.SetValue("email", model.Email);
                message.SetValue("message", model.Message);
                Services.ContentService.SaveAndPublish(message);
                SendMail(model);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        public void SendMail(ContactViewModel model)
        {
            var formEmail = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["SendEmailForm"]);
            var formPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
            var toAddress = new MailAddress(model.Email);
            string subject = System.Configuration.ConfigurationManager.AppSettings["EmailSubject"];
            string body = model.Message;

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(formEmail.Address, formPassword)
            };
            var message = new MailMessage(formEmail, toAddress)
            {
                Subject = subject,
                Body = body,
            };
            smtp.Send(message);
        }
    }
}