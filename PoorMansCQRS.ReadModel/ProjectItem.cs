using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.ReadModel
{
    public class ProjectItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
