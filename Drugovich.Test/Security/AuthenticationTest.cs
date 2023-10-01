using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using Drugovich.Presentation;
using Drugovich.Application.DTOs.Security;
using Drugovich.Domain.Models.Enums;
using Drugovich.Presentation.Controllers.Security;
using Moq;
using Drugovich.Domain.Interfaces.Repositories;
using MediatR;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Drugovich.Application.Commands.Security;
using Microsoft.AspNetCore.Mvc;
using Drugovich.Application.DTOs.App;
using System.Data;

namespace Drugovich.Test.Security
{
    public class AuthenticationTest
    {
        [Fact]
        public async void RegisterManagerTest()
        {
            var model = new RegisterManagerDTO
            {
                Name = "Teste",
                Email = "test@test.com",
                Password = "123456"
            };
            var commandResult = new ManagerDTO
            {
                Name = "Teste",
            };
            var loggerMock = new Mock<ILogger<AuthenticationController>>();
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<RegisterManagerCommand>(), default))
                .ReturnsAsync(commandResult);
            var controller = new AuthenticationController(loggerMock.Object, mediatorMock.Object);

            var result = await controller.Register(model) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(commandResult, result.Value as ManagerDTO);
            mediatorMock.Verify(m => m.Send(It.IsAny<RegisterManagerCommand>(), default), Times.Once);
        }

        [Fact]
        public async void LoginManagerTest()
        {
            var model = new LoginManagerDTO
            {
                Email = "test@test.com",
                Password = "123456"
            };
            var commandResult = new ManagerDTO
            {
                Token = "Test",
            };
            var loggerMock = new Mock<ILogger<AuthenticationController>>();
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<LoginManagerCommand>(), default))
                .ReturnsAsync(commandResult);
            var controller = new AuthenticationController(loggerMock.Object, mediatorMock.Object);

            var result = await controller.Login(model) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            mediatorMock.Verify(m => m.Send(It.IsAny<LoginManagerCommand>(), default), Times.Once);
        }
    }
}
