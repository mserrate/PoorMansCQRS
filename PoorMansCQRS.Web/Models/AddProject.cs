using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PoorMansCQRS.Web.Models
{
    public class AddProject
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]        
        public DateTime DeliveryDate { get; set; }
    }
}