using System;
using NUnit.Framework;
using UnitTesting;
using Moq;

namespace GameCharacterTests;

public class GameCharacterControllerTests
{
    [Test]
    public void FindNotExisting()
    {
        Mock<GameCharacterRepository> mock = new Mock<GameCharacterRepository>();
        GameCharacterController gcc = new GameCharacterController(mock.Object);
        
        mock.Setup(m => m.FindByName("Marcus")).Returns((GameCharacter?)null);
        
        Assert.AreEqual("Not found", gcc.Find("Marcus"));
    }

    [Test]
    public void FindExisting()
    {
        Mock<GameCharacterRepository> mock = new Mock<GameCharacterRepository>();
        GameCharacterController gcc = new GameCharacterController(mock.Object);
        GameCharacter gc = new GameCharacter("Marcus", 123);
        
        mock.Setup(m => m.FindByName("Marcus")).Returns(gc);
        
        Assert.AreEqual(gc.ToString(), gcc.Find("Marcus"));
    }

    [Test]
    public void DeleteNotExisting()
    {
        Mock<GameCharacterRepository> mock = new Mock<GameCharacterRepository>();
        GameCharacterController gcc = new GameCharacterController(mock.Object);
        
        mock.Setup(m => m.DeleteByName("Marcus")).Throws(() => new ArgumentException("Not found"));
        
        Assert.AreEqual("Not found", gcc.Delete("Marcus"));
    }

    [Test]
    public void DeleteExisting()
    {
        Mock<GameCharacterRepository> mock = new Mock<GameCharacterRepository>();
        GameCharacterController gcc = new GameCharacterController(mock.Object);
        
        mock.Setup(m => m.DeleteByName("Marcus")).Verifiable();
        
        Assert.AreEqual("Game character successfully deleted", gcc.Delete("Marcus"));
    }

    [Test]
    public void SaveFailed()
    {
        Mock<GameCharacterRepository> mock = new Mock<GameCharacterRepository>();
        GameCharacterController gcc = new GameCharacterController(mock.Object);
        GameCharacter gc = new GameCharacter("Marcus", 123);
        
        mock.Setup(m => m.Save(gc)).Throws(() => new ArgumentException("Already exists"));

        Assert.AreEqual("Already exists", gcc.Save(gc));
    }

    [Test]
    public void SaveSuccessful()
    {
        Mock<GameCharacterRepository> mock = new Mock<GameCharacterRepository>();
        GameCharacterController gcc = new GameCharacterController(mock.Object);
        GameCharacter gc = new GameCharacter("Marcus", 123);
        
        mock.Setup(m => m.Save(gc)).Verifiable();

        Assert.AreEqual("Game character successfully saved", gcc.Save(gc));
    }
}