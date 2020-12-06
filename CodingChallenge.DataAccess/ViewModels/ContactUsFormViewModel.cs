using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.DataAccess.ViewModels
{
    public class ContactUsFormViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select a value")]
        public string ReasonForContacting { get; set; }

        [StringLength(50, MinimumLength = 10)]
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please provide an email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not valid")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}
