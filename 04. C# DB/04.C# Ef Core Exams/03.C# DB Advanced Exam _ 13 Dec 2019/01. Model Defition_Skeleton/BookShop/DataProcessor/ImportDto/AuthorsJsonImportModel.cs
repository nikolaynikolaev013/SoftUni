﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorsJsonImportModel
    {
        public AuthorsJsonImportModel()
        {
        }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public BookAuthorImportModel[] Books { get; set; }
    }
}


//•	FirstName - text with length [3, 30]. (required)
//•	LastName - text with length[3, 30]. (required)
//•	Email - text(required). Validate it! There is attribute for this job.
//•	Phone - text.Consists only of three groups(separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
//•	AuthorsBooks - collection of type AuthorBook
