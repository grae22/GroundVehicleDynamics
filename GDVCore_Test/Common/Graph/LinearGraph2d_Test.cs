using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDVCore.Common.Graph;

namespace GDVCore_Test.Common.Graph
{
  [TestClass]
  public class LinearGraph2d_Test
  {
    //-------------------------------------------------------------------------

    LinearGraph2d TestOb;

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestOb = new LinearGraph2d();
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void NoGraphPointsX()
    {
      Assert.AreEqual( 0.0, TestOb.GetValueAtX( 123.4 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void OneGraphPointX()
    {
      TestOb.AddPoint( 10.0, 500.0 );

      Assert.AreEqual( 500.0, TestOb.GetValueAtX( 123.4 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void ValuesWithinGraphPointsX()
    {
      // Add some points to the graph.
      TestOb.AddPoint( 0.0, 0.0 );
      TestOb.AddPoint( 1.0, 1.0 );
      TestOb.AddPoint( 11.0, 50.0 );

      // Between points.
      Assert.AreEqual( 0.5, TestOb.GetValueAtX( 0.5 ) );
      Assert.AreEqual( 25.5, TestOb.GetValueAtX( 6.0 ) );

      // At points.
      Assert.AreEqual( 0.0, TestOb.GetValueAtX( 0.0 ) );
      Assert.AreEqual( 1.0, TestOb.GetValueAtX( 1.0 ) );
      Assert.AreEqual( 50.0, TestOb.GetValueAtX( 11.0 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void ValuesOutsideGraphPointsX()
    {
      // Add some points to the graph.
      TestOb.AddPoint( 0.0, 0.0 );
      TestOb.AddPoint( 1.0, 1.0 );
      TestOb.AddPoint( 11.0, 50.0 );

      Assert.AreEqual( 0.0, TestOb.GetValueAtX( -0.5 ) );
      Assert.AreEqual( 50.0, TestOb.GetValueAtX( 11.5 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void NoGraphPointsY()
    {
      Assert.AreEqual( 0.0, TestOb.GetValueAtY( 123.4 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void OneGraphPointY()
    {
      TestOb.AddPoint( 500.0, 10.0 );

      Assert.AreEqual( 500.0, TestOb.GetValueAtY( 123.4 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void ValuesWithinGraphPointsY()
    {
      // Add some points to the graph.
      TestOb.AddPoint( 0.0, 0.0 );
      TestOb.AddPoint( 1.0, 1.0 );
      TestOb.AddPoint( 50.0, 11.0 );

      // Between points.
      Assert.AreEqual( 0.5, TestOb.GetValueAtY( 0.5 ) );
      Assert.AreEqual( 25.5, TestOb.GetValueAtY( 6.0 ) );

      // At points.
      Assert.AreEqual( 0.0, TestOb.GetValueAtY( 0.0 ) );
      Assert.AreEqual( 1.0, TestOb.GetValueAtY( 1.0 ) );
      Assert.AreEqual( 50.0, TestOb.GetValueAtY( 11.0 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void ValuesOutsideGraphPointsY()
    {
      // Add some points to the graph.
      TestOb.AddPoint( 0.0, 0.0 );
      TestOb.AddPoint( 1.0, 1.0 );
      TestOb.AddPoint( 50.0, 11.0 );

      Assert.AreEqual( 0.0, TestOb.GetValueAtY( -0.5 ) );
      Assert.AreEqual( 50.0, TestOb.GetValueAtY( 11.5 ) );
    }

    //-------------------------------------------------------------------------
  }
}
