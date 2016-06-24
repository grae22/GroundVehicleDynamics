using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDVCore.Drivetrain;

namespace GDVCore_Test
{
  [TestClass]
  public class DrivetrainComponentFactory_Test
  {
    //=========================================================================

    private class MockComponent : DrivetrainComponent
    {
      //-----------------------------------------------------------------------

      public MockComponent( string name )
      :
        base( name )
      {

      }

      //-----------------------------------------------------------------------

      public override double ProcessTorqueAndReturnSpeed(
        double deltaTime,
        double inputTorque,
        DrivetrainInputProvider inputProvider )
      {
        return 0.0;
      }

      //-----------------------------------------------------------------------
    }

    //=========================================================================

    [TestMethod]
    public void InstantiateObject()
    {
      DrivetrainComponent component =
        DrivetrainComponentFactory.CreateComponent<MockComponent>(
          "TestComponent" );

      Assert.IsNotNull( component );
      Assert.AreEqual( "TestComponent", component.Name );
    }

    //-------------------------------------------------------------------------
  }
}
