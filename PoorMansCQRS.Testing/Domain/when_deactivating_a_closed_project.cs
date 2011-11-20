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
    public class when_deactivating_a_closed_project
        : ProjectSpecs
    {
        static Exception exception;

        Establish context = () =>
        {
            project = CreateProject();
            project.Close();
        };

        Because of = () =>
            exception = Catch.Exception(() => project.Deactivate());

        It should_rise_a_project_is_closed_exception = () =>
            exception.ShouldBeOfType<ProjectIsClosedException>();
    }
}
