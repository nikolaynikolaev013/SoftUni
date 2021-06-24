using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImportModel
    {
        [Required]
        [RegularExpression("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}
