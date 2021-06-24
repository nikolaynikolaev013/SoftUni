using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class MailImportModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"^[A-z\s0-9]+ str\.$")]
        public string Address { get; set; }
    }
}

//"Mails": [
//      {
//        "Description": "Invalid FullName",
//        "Sender": "Invalid Sender",
//        "Address": "No Address"
//      },
//      {
//        "Description": "Do not put this in your code",
//        "Sender": "My Ansell",
//        "Address": "ha-ha-ha"
//      }