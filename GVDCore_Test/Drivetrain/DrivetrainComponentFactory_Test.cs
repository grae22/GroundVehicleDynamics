using NUnit.Framework;
using GVDCore.Drivetrain;

namespace GVDCore_Test
{
  [TestFixture]
  [Category( "DrivetrainComponentFactory" )]
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

    [Test]
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
