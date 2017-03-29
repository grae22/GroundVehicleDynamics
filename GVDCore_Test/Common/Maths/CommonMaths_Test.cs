using NUnit.Framework;
using GVDCore.Common.Maths;

namespace GVDCore_Test.Common.Maths
{
  [TestFixture]
  [Category( "CommonMaths" )]
  public class CommonMaths_Test
  {
    //-------------------------------------------------------------------------

    [Test]
    public void Lerp()
    {
      Assert.AreEqual(
        10.0,
        CommonMaths.Lerp( 10.0, 20.0, 0.0 ) );

      Assert.AreEqual(
        12.0,
        CommonMaths.Lerp( 10.0, 20.0, 0.2 ) );

      Assert.AreEqual(
        20.0,
        CommonMaths.Lerp( 10.0, 20.0, 1.0 ) );

      // Go out-of-range with clamping.
      Assert.AreEqual(
        20.0,
        CommonMaths.Lerp( 10.0, 20.0, 1.1 ) );

      // Go out-of-range without clamping.
      Assert.AreEqual(
        21.0,
        CommonMaths.Lerp( 10.0, 20.0, 1.1, false ) );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void RangeLerp()
    {
      Assert.AreEqual(
        100.0,
        CommonMaths.Lerp(
          0.0,
          0.0, 10.0,
          100.0, 200.0 ) );

      Assert.AreEqual(
        180.0,
        CommonMaths.Lerp(
          8.0,
          0.0, 10.0,
          100.0, 200.0 ) );

      Assert.AreEqual(
        200.0,
        CommonMaths.Lerp(
          10.0,
          0.0, 10.0,
          100.0, 200.0 ) );

      // Go out-of-range with clamping.
      Assert.AreEqual(
        200.0,
        CommonMaths.Lerp(
          11.0,
          0.0, 10.0,
          100.0, 200.0 ) );

      // Go out-of-range without clamping.
      Assert.AreEqual(
        210.0,
        CommonMaths.Lerp(
          11.0,
          0.0, 10.0,
          100.0, 200.0,
          false ) );
    }

    //-------------------------------------------------------------------------
  }
}
