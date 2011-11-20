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
    public class when_closing_a_project
        : ProjectSpecs
    {
        static IEvent @event;

        Establish context = () =>
            {
                project = CreateProject();
                DomainEvents.Register<ProjectClosedEvent>(e => @event = e);
            };

        Because of = () =>
            project.Close();

        It should_create_a_projectclosed_event = () =>
            @event.ShouldBeOfType<ProjectClosedEvent>();
    }
}
