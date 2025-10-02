using Moq;
using api.Services;
using api.Models;

namespace api.tests;

[TestClass]
public sealed class Test1
{
    private Mock<IUserService> _mockUserService;
    private List<User> _testUsers;
    [TestInitialize]
    public void Setup()
    {
        _mockUserService = new Mock<IUserService>();
        _testUsers = new List<User>
        {
            new User(1, "Test", "test@example.com", "password"),
            new User(2, "User", "user@example.com", "password")
        };
    }

    [TestMethod]
    public void TestMethodWithMoq()
    {
        // Arrange

        _mockUserService.Setup(x => x.GetUserById(1))
                   .Returns(new User(1, "Test", "test@example.com", "password"));

        // Act & Assert
        var result = _mockUserService.Object.GetUserById(1);
        Assert.IsNotNull(result);
        Assert.AreEqual("Test", result.Name);
    }
    [TestMethod]
    public void GetAllUsers_ShouldReturnAllUsers()
    {
        // Arrange
        _mockUserService.Setup(x => x.GetAllUsers()).Returns(_testUsers);

        // Act
        var result = _mockUserService.Object.GetAllUsers();

        // Assert
        Assert.AreEqual(2, result.Count());
        Assert.AreEqual("Test", result.First().Name);
    }
}
