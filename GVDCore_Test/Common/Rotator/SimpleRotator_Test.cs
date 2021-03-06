﻿using NUnit.Framework;
using GVDCore.Common.Rotator;

namespace GVDCore_Test.Common.Rotator
{
  [TestFixture]
  [Category( "SimpleRotator" )]
  public class SimpleRotator_Test
  {
    //-------------------------------------------------------------------------

    private SimpleRotator TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void Initialise()
    {
      TestObject = new SimpleRotator( 10.0, 0.1 );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedInitiallyZero()
    {
      Assert.AreEqual( 0.0, TestObject.GetRps() );
      Assert.AreEqual( 0.0, TestObject.GetRpm() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterForce()
    {
      const double F = 1000.0;

      // Apply force and let object update.
      TestObject.ApplyTangentForce( F );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = F * TestObject.Radius;
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTwoForces()
    {
      const double F1 = 1000.0;
      const double F2 = 100.0;

      // Apply force and let object update.
      TestObject.ApplyTangentForce( F1 );
      TestObject.ApplyTangentForce( F2 );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = ( F1 + F2 ) * TestObject.Radius;
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTwoTimeSeparatedForces()
    {
      const double F1 = 1000.0;
      const double F2 = 100.0;

      // Apply force and let object update.
      TestObject.ApplyTangentForce( F1 );
      TestObject.Update( 1.0 );
      TestObject.ApplyTangentForce( F2 );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = ( F1 + F2 ) * TestObject.Radius;
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTwoOpposingForces()
    {
      const double F1 = 1000.0;
      const double F2 = -1000.0;

      // Apply force and let object update.
      TestObject.ApplyTangentForce( F1 );
      TestObject.ApplyTangentForce( F2 );
      TestObject.Update( 1.0 );

      // Test.
      Assert.AreEqual( 0.0, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTorque()
    {
      const double T = 1000.0;

      // Apply force and let object update.
      TestObject.ApplyTorque( T );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTwoTorques()
    {
      const double T1 = 1000.0;
      const double T2 = 100.0;

      // Apply force and let object update.
      TestObject.ApplyTorque( T1 );
      TestObject.ApplyTorque( T2 );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = ( T1 + T2 ) / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTwoTimeSeparatedTorques()
    {
      const double T1 = 1000.0;
      const double T2 = 100.0;

      // Apply force and let object update.
      TestObject.ApplyTorque( T1 );
      TestObject.Update( 1.0 );
      TestObject.ApplyTorque( T2 );
      TestObject.Update( 1.0 );

      // Calc expected value.
      double T = ( T1 + T2 );
      double I = ( TestObject.Mass * ( TestObject.Radius * TestObject.Radius ) ) / 2.0;
      double a = T / I;

      // Test.
      Assert.AreEqual( a, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SpeedAfterTwoOpposingTorques()
    {
      const double T1 = 1000.0;
      const double T2 = -1000.0;

      // Apply force and let object update.
      TestObject.ApplyTorque( T1 );
      TestObject.ApplyTorque( T2 );
      TestObject.Update( 1.0 );

      // Test.
      Assert.AreEqual( 0.0, TestObject.GetRps() );
    }

    //-------------------------------------------------------------------------
  }
}
