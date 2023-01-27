using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using UsersWeb.API.Controllers;
using System.Threading.Tasks;
using Xunit;
using Moq;
using UsersWeb.API.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using UsersWeb.UnitTests.Fixtures;

namespace UsersWeb.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_Returns_StatusCode200()
    {
        // Arrange 
        // Create a mock of the IUserService interface 
        var moqUserService = new Mock<IUserService>();
        // Setup the mock to return a list of users when the GetUsers method is called 
        moqUserService.Setup(x => x.GetUsers())
            .ReturnsAsync(UserFixtureBase.GetTestUsers);

        // Create an instance of the controller and inject the mock  
        var sut = new UserController(moqUserService.Object);
        //Act
        // 
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }


    [Fact]
    public async Task Get_OnSuccess_InvokesUserServicOnce()
    {
        //Arrange
        // Create a mock of the IUserService
        var moqUserService = new Mock<IUserService>();
        // Setup the mock to return a list of users when the GetUsers method is called
        moqUserService.Setup(x => x.GetUsers()).ReturnsAsync(new List<User>());

        // Create an instance of the controller and inject the mock
        var sut = new UserController(moqUserService.Object);

        //Act
        var result = await sut.Get();
        // Assert 
        moqUserService.Verify(
            x => x.GetUsers(),
            Times.Once);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        //Arrange
        // Create a mock of the IUserService
        var moqUserService = new Mock<IUserService>();
        // Setup the mock to return a list of users when the GetUsers method is called
        moqUserService
            .Setup(x => x.GetUsers())
            .ReturnsAsync(UserFixtureBase.GetTestUsers);

        // Create an instance of the controller and inject the mock
        var sut = new UserController(moqUserService.Object);

        //Act
        var result = await sut.Get();

        // Assert 
        result.Should().BeOfType<OkObjectResult>();
        var objectresult = (OkObjectResult)result;
        objectresult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        var moqUsersService = new Mock<IUserService>();

        moqUsersService.Setup(x => x.GetUsers()).ReturnsAsync(new List<User>());

        var sut = new UserController(moqUsersService.Object);

        var result = await sut.Get();
        
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

}