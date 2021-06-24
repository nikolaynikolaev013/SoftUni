using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class MailsJsonImportModel
    {

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"^[A-z\s0-9]+ str.$")]
        public string Address { get; set; }
    }
}


//{
//        "Description": "Invalid FullName",
//        "Sender": "Invalid Sender",
//        "Address": "No Address"
//      },