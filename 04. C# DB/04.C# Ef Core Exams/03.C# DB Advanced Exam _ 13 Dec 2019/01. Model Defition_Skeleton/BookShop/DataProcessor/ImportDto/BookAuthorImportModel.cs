using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class BookAuthorImportModel
    {
        [Required]
        public int? Id { get; set; }
    }
}