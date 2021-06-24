using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerMailsImportModel
    {
        public PrisonerMailsImportModel()
        {
        }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^The [A-Z]{1}[A-z]+$")]
        public string NickName { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? Bail { get; set; }

        public int CellId { get; set; }

        public ICollection<MailImportModel> Mails { get; set; }
    }
}
