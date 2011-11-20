using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using PoorMansCQRS.Domain;
using PoorMansCQRS.Domain.DomainEvents;
using PoorMansCQRS.Domain.Exceptions;

namespace PoorMansCQRS.Testing.Domain
{
    [Subject(typeof(Project))]
    public class when_changing_a_project_delivery_date_before_today
        : ProjectSpecs
    {
        static DateTime current;
        static DateTime expected;
        static Exception exception;

        Establish context = () =>
        {
            project = CreateProject();
            DomainEvents.Register<DeliveryDateChangedEvent>(p => expected = p.DeliveryDate);

            current = DateTime.Now.AddDays(-1);
        };

        Because of = () =>
            exception = Catch.Exception(() => project.ChangeDeliveryDate(current));

        It should_raise_an_invalid_delivery_date_exception = () =>
              exception.ShouldBeOfType<InvalidDeliveryDateException>();
    }
}
