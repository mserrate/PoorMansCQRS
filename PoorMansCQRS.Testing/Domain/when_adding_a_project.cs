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
    public class when_adding_a_project
        : ProjectSpecs
    {
        static IEvent @event;

        Establish context = () =>
        {
            DomainEvents.Register<ProjectAddedEvent>(p => @event = p);
        };

        Because of = () =>
            project = CreateProject();

        It should_create_project_created_event = () =>
              @event.ShouldBeOfType<ProjectAddedEvent>();
    }
}
