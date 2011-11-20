using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PoorMansCQRS.Web.Models
{
    public class AddTask
    {
        public Guid ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Description { get; set; }
    }
}