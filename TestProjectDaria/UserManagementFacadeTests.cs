using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class UserManagementFacadeTests
{
    [Test]
    public void AddUser_ShouldAddUserSuccessfully()
    {
        // Arrange
        var users = new List<User>();
        var facade = new UserManagementFacade(users);

        // Act
        facade.AddUser("testuser", "password123", "Administrator");

        // Assert
        Assert.AreEqual(1, users.Count);
        Assert.AreEqual("testuser", users[0].Username);
        Assert.AreEqual("Administrator", users[0].Role);
    }

    [Test]
    public void Authenticate_ShouldReturnUserWhenValid()
    {
        // Arrange
        var users = new List<User> { new User { Username = "admin", Password = "admin", Role = "Administrator" } };
        var facade = new UserManagementFacade(users);

        // Act
        var result = facade.Authenticate("admin", "admin");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("admin", result.Username);
        Assert.AreEqual("Administrator", result.Role);
    }

    [Test]
    public void Authenticate_ShouldReturnNullWhenInvalid()
    {
        // Arrange
        var users = new List<User>();
        var facade = new UserManagementFacade(users);

        // Act
        var result = facade.Authenticate("invalid", "invalid");

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void DeleteUser_ShouldRemoveUserSuccessfully()
    {
        // Arrange
        var users = new List<User> { new User { Username = "user1", Password = "pass", Role = "Opiekun" } };
        var facade = new UserManagementFacade(users);

        // Act
        var result = facade.DeleteUser("user1");

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(0, users.Count);
    }

    [Test]
    public void DeleteUser_ShouldReturnFalseWhenUserNotFound()
    {
        // Arrange
        var users = new List<User>();
        var facade = new UserManagementFacade(users);

        // Act
        var result = facade.DeleteUser("nonexistentuser");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void EditUser_ShouldUpdateUserDetails()
    {
        // Arrange
        var users = new List<User> { new User { Username = "user1", Password = "oldpass", Role = "Opiekun" } };
        var facade = new UserManagementFacade(users);

        // Act
        var result = facade.EditUser("user1", "newpass", "Administrator");

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual("newpass", users[0].Password);
        Assert.AreEqual("Administrator", users[0].Role);
    }

    [Test]
    public void EditUser_ShouldReturnFalseWhenUserNotFound()
    {
        // Arrange
        var users = new List<User>();
        var facade = new UserManagementFacade(users);

        // Act
        var result = facade.EditUser("nonexistentuser", "newpass", "Administrator");

        // Assert
        Assert.IsFalse(result);
    }
}
