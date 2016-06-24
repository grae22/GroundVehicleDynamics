using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDVCore.Common.Rotator;

namespace GDVCore_Test.Common.Rotator
{
  [TestClass]
  public class FrictionlessRotator_Test
  {
    //-------------------------------------------------------------------------

    private FrictionlessRotator TestObject;

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = new FrictionlessRotator();
      TestObject.Mass = 10.0;
      TestObject.Radius = 0.1;
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SpeedInitiallyZero()
    {
      Assert.AreEqual( 0.0, TestObject.GetRps() );
      Assert.AreEqual( 0.0, TestObject.GetRpm() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SpeedAfterForce()
    {
      const double F = 1000.0;

      // Apply force and let object update.
      TestObject.ApplyForce( F );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = F * TestObject.Radius;
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SpeedAfterTwoForces()
    {
      const double F1 = 1000.0;
      const double F2 = 100.0;

      // Apply force and let object update.
      TestObject.ApplyForce( F1 );
      TestObject.ApplyForce( F2 );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = ( F1 + F2 ) * TestObject.Radius;
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SpeedAfterTwoTimeSeparatedForces()
    {
      const double F1 = 1000.0;
      const double F2 = 100.0;

      // Apply force and let object update.
      TestObject.ApplyForce( F1 );
      TestObject.Update( 1.0 );
      TestObject.ApplyForce( F2 );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = ( F1 + F2 ) * TestObject.Radius;
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SpeedAfterTwoOpposingForces()
    {
      const double F1 = 1000.0;
      const double F2 = -1000.0;

      // Apply force and let object update.
      TestObject.ApplyForce( F1 );
      TestObject.ApplyForce( F2 );
      TestObject.Update( 1.0 );

      // Test.
      Assert.AreEqual( 0.0, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------
  }
}
