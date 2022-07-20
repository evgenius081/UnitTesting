using System;
using NUnit.Framework;
using UnitTesting;

namespace GameCharacterTests;

public class GameCharacterRepositoryTests
{
    [Test]
    public void FindNotExisting()
    {
        GameCharacterRepository gcr = new GameCharacterRepository();
        
        Assert.AreEqual(null, gcr.FindByName("Marcus"));
    }

    [Test]
    public void FindExisting()
    {
        GameCharacterRepository gcr = new GameCharacterRepository();
        GameCharacter gc = new GameCharacter("Marcus", 123);
        gcr.Save(gc);
        
        Assert.AreEqual(gc, gcr.FindByName("Marcus"));
    }

    [Test]
    public void DeleteNotExisting()
    {
        GameCharacterRepository gcr = new GameCharacterRepository();
        
        Assert.Throws<ArgumentException>(() => gcr.DeleteByName("Marcus"));
    }

    [Test]
    public void DeleteExisting()
    {
        GameCharacterRepository gcr = new GameCharacterRepository();
        GameCharacter gc = new GameCharacter("Marcus", 123);
        gcr.Save(gc);
        
        Assert.DoesNotThrow(() => gcr.DeleteByName("Marcus"));
    }

    [Test]
    public void SaveFailed()
    {
        GameCharacterRepository gcr = new GameCharacterRepository();
        GameCharacter gc = new GameCharacter("Marcus", 123);
        gcr.Save(gc);

        Assert.Throws<ArgumentException>(() => gcr.Save(gc));
    }

    [Test]
    public void SaveSuccessful()
    {
        GameCharacterRepository gcr = new GameCharacterRepository();
        GameCharacter gc = new GameCharacter("Marcus", 123);
        
        Assert.DoesNotThrow(() => gcr.Save(gc));
    }
}