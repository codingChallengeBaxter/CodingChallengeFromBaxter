using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using CodingChallenge.DataAccess.ViewModels;

namespace CodingChallenge.DataAccess.CommandHandler
{
    public class EmailSender
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
        public ContactUsFormViewModel ContactUsFormViewModel { get; set; }

        public string ForeName(string fullName)
        {
            if (fullName != null)
            {
                return fullName.Split(' ')[0];
            }

            return "User";
        }

        public EmailSender(ContactUsFormViewModel contactUsFormViewModel)
        {

            ContactUsFormViewModel = new ContactUsFormViewModel();
            this.To = contactUsFormViewModel.EmailAddress;
            this.Subject = "Thank you for getting in touch";
            this.Body =
                "<html>" +
                "   <body>" +
                "     <h4>Dear " + $"{ForeName(contactUsFormViewModel.FullName)}" + "</h4>" +

                "      <p style='font-family: Arial; color: black;font-size: 14px;'>Thank you for contacting us. We will get in touch with you       shortly.</p>" +
                "      <div width=40%;>" +
                "         <p  style='font-size: 13px;'>Regards </br>" +
                "            Coding Challenge Team" +
                "      </div>" +
                "   </body>" +
                "</html>";
        }


        public bool SendEmailAfterSubmittingContactUsForm()
        {
            bool success;

            var from = System.Configuration.ConfigurationManager.AppSettings["AddressToSendEmailFrom"]
                .ToString(CultureInfo.InvariantCulture);
            var passWord = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString(CultureInfo.InvariantCulture);


            using (MailMessage mail = new MailMessage(from, To))
            {

                mail.IsBodyHtml = true;
                ContentType contentType = new ContentType();
                contentType.MediaType = MediaTypeNames.Application.Octet;
                contentType.Name = "New-Assign04.json";
                mail.Body = Body;

                SmtpClient smpClient = new SmtpClient("smtp-mail.outlook.com", 587);
                smpClient.EnableSsl = true;

                NetworkCredential networkCredential = new NetworkCredential(from, passWord);
                smpClient.UseDefaultCredentials = true;
                smpClient.Credentials = networkCredential;

                try
                {
                    smpClient.Send(mail);
                    success = true;
                }
                catch (Exception exception)
                {
                    success = false;
                }
            }

            return success;
        }

    }
}
