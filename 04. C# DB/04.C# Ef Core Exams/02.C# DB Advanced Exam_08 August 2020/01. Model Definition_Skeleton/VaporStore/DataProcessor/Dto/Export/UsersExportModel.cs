using System.Collections.Generic;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UsersExportModel
    {
        public UsersExportModel()
        {
        }
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public UserPurchaseExportModel[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}

//< Users >
//  < User username = "mgraveson" >
 
//     < Purchases >
 
//       < Purchase >
 
//         < Card > 7991 7779 5123 9211 </ Card >
    
//            < Cvc > 340 </ Cvc >
    
//            < Date > 2017 - 08 - 31 17:09 </ Date >
           
//                   < Game title = "Counter-Strike: Global Offensive" >
            
//                      < Genre > Action </ Genre >
            
//                      < Price > 12.49 </ Price >
            
//                    </ Game >
            
//                  </ Purchase >
