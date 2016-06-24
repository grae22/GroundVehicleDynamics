using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDVCore.Common.Graph;

namespace GDVCore_Test.Common.Graph
{
  [TestClass]
  public class Graph2d_Test
  {
    //-------------------------------------------------------------------------

    private class MockGraph2d : Graph2d
    {
      public override double GetValueAtX( double xPosition )
      {
        return 0.0;
      }

      public override double GetValueAtY( double yPosition )
      {
        return 0.0;
      }
    }

    //=========================================================================

    private Graph2d TestOb;

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Intialise()
    {
      TestOb = new MockGraph2d();
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddPoints()
    {
      TestOb.AddPoint( 1.0, 2.0 );
      TestOb.AddPoint( 3.0, 4.0 );

      Assert.AreEqual( 1.0, TestOb.GetPoint( 0 ).x );
      Assert.AreEqual( 2.0, TestOb.GetPoint( 0 ).y );
      Assert.AreEqual( 3.0, TestOb.GetPoint( 1 ).x );
      Assert.AreEqual( 4.0, TestOb.GetPoint( 1 ).y );

      Assert.AreEqual( 2, TestOb.GetPointCount() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SetPoints()
    {
      // Add some points.
      TestOb.AddPoint( 1.0, 2.0 );
      TestOb.AddPoint( 3.0, 4.0 );

      // Now try set a point.
      TestOb.SetPoint( 1, 30.0, 40.0 );

      Assert.AreEqual( 30.0, TestOb.GetPoint( 1 ).x );
      Assert.AreEqual( 40.0, TestOb.GetPoint( 1 ).y );

      Assert.AreEqual( 2, TestOb.GetPointCount() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SetPointOutOfBounds()
    {
      bool caughtException = false;

      // Try set a point when there aren't any.
      try
      {
        TestOb.SetPoint( 0, 0.0, 0.0 );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsTrue( caughtException );

      // Add some points.
      TestOb.AddPoint( 1.0, 2.0 );
      TestOb.AddPoint( 3.0, 4.0 );

      // Try set a point that's out-of-bounds.
      caughtException = false;

      try
      {
        TestOb.SetPoint( -1, 0.0, 0.0, false );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsTrue( caughtException );

      // Try set another point that's out-of-bounds.
      caughtException = false;

      try
      {
        TestOb.SetPoint( 2, 0.0, 0.0, false );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsTrue( caughtException );

      // Try set another point that's out-of-bounds, but allow clamping now.
      caughtException = false;

      try
      {
        TestOb.SetPoint( 2, 0.0, 0.0 );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsFalse( caughtException );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetPointOutOfBounds()
    {
      bool caughtException = false;

      // Try get a point when there aren't any.
      try
      {
        TestOb.GetPoint( 0 );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsTrue( caughtException );

      // Add some points.
      TestOb.AddPoint( 1.0, 2.0 );
      TestOb.AddPoint( 3.0, 4.0 );

      // Try get a point that's out-of-bounds.
      caughtException = false;

      try
      {
        TestOb.GetPoint( -1, false );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsTrue( caughtException );

      // Try get another point that's out-of-bounds.
      caughtException = false;

      try
      {
        TestOb.GetPoint( 2, false );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsTrue( caughtException );

      // Try get another point that's out-of-bounds, but allow clamping now.
      caughtException = false;

      try
      {
        TestOb.GetPoint( 2 );
      }
      catch( IndexOutOfRangeException )
      {
        caughtException = true;
      }

      Assert.IsFalse( caughtException );
    }

    //-------------------------------------------------------------------------
  }
}
