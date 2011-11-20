using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Domain;
using Machine.Specifications;
using Microsoft.Practices.ServiceLocation;
using PoorMansCQRS.Domain.DomainEvents;

namespace PoorMansCQRS.Testing.Domain
{
    public abstract class ProjectSpecs
    {
        protected static Project project;

        Establish basecontext = () =>
        {
            // mocking the service locator used by Domain Events
            var mock = new Moq.Mock<IServiceLocator>();
            mock.Setup(x => x.GetAllInstances(typeof(IEventHandler<>))).Returns(new List<object>());
            ServiceLocator.SetLocatorProvider(() => mock.Object);
        };

        Cleanup resources = () =>
        {
            DomainEvents.ClearCallbacks();
        };

        protected static Project CreateProject()
        {
            return new Project("p1", "Project 1", DateTime.Now.AddDays(5));
        }
    }
}
