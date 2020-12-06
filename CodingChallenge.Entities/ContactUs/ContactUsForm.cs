using System;

namespace CodingChallenge.Entities.ContactUs
{
    public class ContactUsForm
    {
        public int ID { get; set; }
        public string ReasonForContacting { get; set; }
        public string FullName { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public DateTime DateContactMade { get; set; }
    }
}
