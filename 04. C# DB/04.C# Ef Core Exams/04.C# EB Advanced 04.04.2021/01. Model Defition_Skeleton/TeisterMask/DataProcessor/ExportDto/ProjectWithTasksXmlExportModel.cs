using System;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectWithTasksXmlExportModel
    {
        public ProjectWithTasksXmlExportModel()
        {
        }

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TasksXmlExportModel[] Tasks { get; set; }
    }
}

//< Projects >
//  < Project TasksCount = "10" >
 
//     < ProjectName > Hyster - Yale </ ProjectName >
 
//     < HasEndDate > No </ HasEndDate >
 
//     < Tasks >
 
//       < Task >
 
//         < Name > Broadleaf </ Name >
 
//         < Label > JavaAdvanced </ Label >
 
//       </ Task >
 
//       < Task >
 
//         < Name > Bryum </ Name >
 
//         < Label > EntityFramework </ Label >
 
//       </ Task >
 
//       < Task >
 
//         < Name > Cornflag </ Name >
 
//         < Label > CSharpAdvanced </ Label >
 
//       </ Task >
