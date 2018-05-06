﻿using System;
using AutoMapper;
using Geoloc.Data.Entities;
using Geoloc.Data.Repositories.Abstract;
using Geoloc.Infrastructure;
using Geoloc.Services.Abstract;
using Moq;
using NUnit.Framework;

namespace Geoloc.Tests.Services
{
    [TestFixture]
    public class UserService
    {
        private Mock<IAppUserRepository> _repoMock;
        private IUserService _userService;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            Mapper.Reset();
            Mapper.Initialize(c => c.AddProfile(new AutoMapperConfiguration()));
        }

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IAppUserRepository>();
            _userService = new Geoloc.Services.UserService(_repoMock.Object);
        }

        [Test]
        public void GetById_GivenExistingId_ReturnsExpectedUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new AppUser {Id = userId, UserName = "TestUser"};
            _repoMock.Setup(x => x.Get(userId)).Returns(user);

            // Act
            var result = _userService.GetById(userId);

            // Assert
            Assert.AreEqual(user.UserName, result.UserName);
        }

        [Test]
        public void GetById_GivenNonExistingId_ReturnsNull()
        {
            // Arrange
            _repoMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns((AppUser) null);

            // Act
            var result = _userService.GetById(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetByUserName_GivenExistingName_ReturnsExpectedUser()
        {
            // Arrange
            const string userName = "TestUser";
            var user = new AppUser { UserName = "TestUser" };
            _repoMock.Setup(x => x.Get(userName)).Returns(user);

            // Act
            var result = _userService.GetByUserName(userName);

            // Assert
            Assert.AreEqual(user.UserName, result.UserName);
        }

        [Test]
        public void GetByUserName_GivenNonExistingName_ReturnsNull()
        {
            // Arrange
            _repoMock.Setup(x => x.Get(It.IsAny<string>())).Returns((AppUser)null);

            // Act
            var result = _userService.GetByUserName("abc");

            // Assert
            Assert.IsNull(result);
        }
    }
}
