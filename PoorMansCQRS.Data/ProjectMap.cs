using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PoorMansCQRS.Domain;
using FluentNHibernate;

namespace PoorMansCQRS.Data
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(Reveal.Member<Project>("_id"), "Id").GeneratedBy.Assigned();
            Map(Reveal.Member<Project>("_code"), "Code");
            Map(Reveal.Member<Project>("_name"), "Name");
            Map(Reveal.Member<Project>("_deliveryDate"), "DeliveryDate");
            Map(Reveal.Member<Project>("_status"), "Status").CustomType<int>();
            HasMany<Task>(Reveal.Member<Project>("_tasks")).KeyColumn("ProjectId").Cascade.All();
        }
    }
}
