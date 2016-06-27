using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GVDCore.Drivetrain;
using GVDCore.Drivetrain.Component;

namespace GVDCore_Test.Drivetrain
{
  [TestClass]
  public class DrivetrainManager_Test
  {
    //-------------------------------------------------------------------------

    private DrivetrainManager TestOb { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestOb = new DrivetrainManager();
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddComponents()
    {
      TestOb.AddComponent<SimpleEngine>( null, "Engine" );
      TestOb.AddComponent<SimpleEngine>( "Engine", "Engine2" );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddComponentsDualEngine()
    {
      TestOb.AddComponent<SimpleEngine>( null, "Engine1" );
      TestOb.AddComponent<SimpleEngine>( null, "Engine2" );

      TestOb.AddComponent<SimpleEngine>( "Engine1", "Engine1_1" );
      TestOb.AddComponent<SimpleEngine>( "Engine2", "Engine2_1" );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    [ExpectedException( typeof( Exception ) ) ]
    public void AddComponentAfterInvalidComponent()
    {
      TestOb.AddComponent<SimpleEngine>( "ComponentThatDoesntExist", "Engine" );
    }

    //-------------------------------------------------------------------------
  }
}
