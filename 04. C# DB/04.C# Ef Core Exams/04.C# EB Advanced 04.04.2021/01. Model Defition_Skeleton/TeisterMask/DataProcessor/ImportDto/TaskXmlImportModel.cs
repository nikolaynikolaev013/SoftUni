﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class TaskXmlImportModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [EnumDataType(typeof(ExecutionType))]
        [XmlElement("ExecutionType")]
        public string ExecutionType { get; set; }

        [EnumDataType(typeof(LabelType))]
        [XmlElement("LabelType")]
        public string LabelType { get; set; }

    }
}

//•	Id - integer, Primary Key
//•	Name - text with length [2, 40] (required)
//•	OpenDate - date and time(required)
//•	DueDate - date and time(required)
//•	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
//•	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
//•	ProjectId - integer, foreign key(required)
//•	Project - Project
//•	EmployeesTasks - collection of type EmployeeTask



//< Task >
//        < Name > Australian </ Name >
//        < OpenDate > 19 / 08 / 2018 </ OpenDate >
//        < DueDate > 13 / 07 / 2019 </ DueDate >
//        < ExecutionType > 2 </ ExecutionType >
//        < LabelType > 0 </ LabelType >
//      </ Task >