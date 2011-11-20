using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PoorMansCQRS.Web.Models
{
    public class ChangeDeliveryDate
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
    }
}