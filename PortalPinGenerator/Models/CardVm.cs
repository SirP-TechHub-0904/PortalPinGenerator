using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalPinGenerator.Models
{
    public class CardVm
    {
        [Required]
        public string School { get; set; }

        [Required]
        public int Numbers { get; set; }

        [Required]
        public string BatchNumber { get; set; }
    }
}