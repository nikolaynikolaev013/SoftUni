﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftJail.Data.Models.Enums;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();

        }
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }


    }
}

//•	DepartmentId - integer, foreign key(required)
//•	Department – the officer's department (required)
//•	OfficerPrisoners - collection of type OfficerPrisoner
