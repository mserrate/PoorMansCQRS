using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using PoorMansCQRS.Domain;
using PoorMansCQRS.Domain.DomainEvents;

namespace PoorMansCQRS.Testing.Domain
{
    [Subject(typeof(Project))]
    public class when_changing_a_project_delivery_date_after_today
        : ProjectSpecs
    {
        static DateTime current;
        static DateTime expected;

        Establish context = () =>
        {
            current = DateTime.Now.AddDays(10);
            project = CreateProject();
            DomainEvents.Register<DeliveryDateChangedEvent>(p => expected = p.DeliveryDate);
        };

        Because of = () =>
            project.ChangeDeliveryDate(current);

        It should_create_DeliveryDateChangedEvent = () =>
              current.ShouldEqual(expected);
    }
}
