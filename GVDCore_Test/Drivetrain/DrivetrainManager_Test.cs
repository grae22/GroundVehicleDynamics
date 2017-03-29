using System;
using NUnit.Framework;
using GVDCore.Drivetrain;
using GVDCore.Drivetrain.Component;

namespace GVDCore_Test.Drivetrain
{
  [TestFixture]
  [Category( "DrivetrainManager" )]
  public class DrivetrainManager_Test
  {
    //-------------------------------------------------------------------------

    private DrivetrainManager TestOb { get; set; }

    //-------------------------------------------------------------------------

    [SetUp]
    public void Initialise()
    {
      TestOb = new DrivetrainManager();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void AddComponents()
    {
      TestOb.AddComponent<SimpleEngine>( null, "Engine" );
      TestOb.AddComponent<SimpleEngine>( "Engine", "Engine2" );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void AddComponentsDualEngine()
    {
      TestOb.AddComponent<SimpleEngine>( null, "Engine1" );
      TestOb.AddComponent<SimpleEngine>( null, "Engine2" );

      TestOb.AddComponent<SimpleEngine>( "Engine1", "Engine1_1" );
      TestOb.AddComponent<SimpleEngine>( "Engine2", "Engine2_1" );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void AddComponentAfterInvalidComponent()
    {
      try
      {
        TestOb.AddComponent<SimpleEngine>( "ComponentThatDoesntExist", "Engine" );
      }
      catch( Exception )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------
  }
}
