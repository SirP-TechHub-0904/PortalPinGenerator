using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalPinGenerator.Models
{
    public class Card
    {
        
        public int Id { get; set; }
        public string PinNumber { get; set; }
        public string SerialNumber { get; set; }
        public string School { get; set; }
        public string BatchNumber { get; set; }
       
    }
}