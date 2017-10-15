﻿using ContactUS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Web.Tests.Controllers.Contact
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenProjectsServiceIsNull()
        {
            // Arrange
            var ContactServiceMock = Mock.Create<IContactService>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ContactController(ContactServiceMock));
        }

        [TestMethod]
        public void ThrowWhenUsersServiceIsNull()
        {
            // Arrange
            var projectssServiceMock = Mock.Create<IProjectsService>();
            var authMock = Mock.Create<IAuthProvider>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProjectsController(projectssServiceMock, null, authMock));
        }

        [TestMethod]
        public void SetPassedDataCorrectlyWhenDataIsNotNull()
        {
            // Arrange
            var projectssServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();

            // Act
            var controller = new ProjectsController(projectssServiceMock, usersServiceMock, authMock);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
