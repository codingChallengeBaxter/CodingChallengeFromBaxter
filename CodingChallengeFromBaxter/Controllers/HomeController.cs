using System;
using System.Web.Mvc;
using CodingChallenge.DataAccess;
using CodingChallenge.DataAccess.CommandHandler;
using CodingChallenge.DataAccess.ViewModels;
using CodingChallenge.Entities.ContactUs;

namespace CodingChallengeFromBaxter.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodingChallengeDbContext _codingChallengeDbContext = new CodingChallengeDbContext();
        private EmailSender _emailSender;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitContactUsForm(ContactUsFormViewModel contactUsFormViewModel)
        {
            bool contactUsFormSavedSuccessfully = false;
            bool emailSentSuccessfully = false;

            if (ModelState.IsValid)
            {
                ContactUsForm contactUsForm = new ContactUsForm();

                contactUsForm.FullName = contactUsFormViewModel.FullName;
                contactUsForm.ReasonForContacting = contactUsFormViewModel.ReasonForContacting;
                contactUsForm.EmailAddress = contactUsFormViewModel.EmailAddress;
                contactUsForm.PhoneNumber = contactUsFormViewModel.PhoneNumber;
                contactUsForm.Message = contactUsFormViewModel.Message;
                contactUsForm.DateContactMade = DateTime.Now;

                _codingChallengeDbContext.ContactUsForms.Add(contactUsForm);
                _codingChallengeDbContext.SaveChanges();

                contactUsFormSavedSuccessfully = true;

            }

            if (contactUsFormSavedSuccessfully)
            {
                // send Email
                _emailSender = new EmailSender(contactUsFormViewModel);
                emailSentSuccessfully = _emailSender.SendEmailAfterSubmittingContactUsForm();
            }

            return new JsonResult
            {
                Data = new
                {
                    contactUsFormSavedSuccessfully,
                    emailSentSuccessfully
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}