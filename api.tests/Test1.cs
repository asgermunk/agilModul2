using Moq;
using api.Services;
using api.Models;

namespace api.tests;

[TestClass]
public sealed class Test1
{
   

    [TestMethod]
    public void TestMethodWithMoq()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.Setup(x => x.GetUserById(1))
                   .Returns(new User(1, "Test", "test@example.com", "password"));
        
        // Act & Assert
        var result = mockUserService.Object.GetUserById(1);
        Assert.AreEqual("Test", result.Name);
    }
}
