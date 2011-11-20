using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.Data
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Id(Reveal.Member<Task>("_id"), "Id").GeneratedBy.Assigned();
            References<Project>(Reveal.Member<Task>("_aggregateRoot")).Column("ProjectId").Not.Nullable();
            Map(Reveal.Member<Task>("_name"), "Name");
            Map(Reveal.Member<Task>("_description"), "Description");
            Map(Reveal.Member<Task>("_status"), "Status").CustomType<int>();
        }
    }
}
