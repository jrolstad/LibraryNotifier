using System;
using System.Collections.Generic;
using System.Linq;
using LibraryNotifier.Web.Controllers;
using LibraryNotifier.Web.Infrastructure;
using NUnit.Framework;
using Ninject;

namespace LibraryNotifier.Web.Test.Infrastructure
{
    [TestFixture]
    public class DependencyInjectionTests
    {

        [Test]
        [TestCase(typeof(SearchableItemsController))]
        public void The_instance_can_be_resolved(Type typeToGet)
        {
            // Arrange
            var kernel = new StandardKernel();

            Bootstrapper.Configure(kernel);

            // Act
            var result = kernel.Get(typeToGet);

            // Assert

        }

    }
}