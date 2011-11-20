using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PoorMansCQRS.ReadModel
{
    public class ProjectDetails
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
