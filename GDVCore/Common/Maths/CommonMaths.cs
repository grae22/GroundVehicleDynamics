using System;

namespace GDVCore.Common.Maths
{
  static class CommonMaths
  {
    //-------------------------------------------------------------------------

    public const double TwoPI = ( Math.PI * 2.0 );

    //-------------------------------------------------------------------------

    public static double Lerp(
      double value1,
      double value2,
      double position,
      bool clampToBounds = true )
    {
      if( clampToBounds )
      {
        if( position < 0.0 )
        {
          position = 0.0;
        }
        else if( position > 1.0 )
        {
          position = 1.0;
        }
      }

      return value1 + ( ( value2 - value1 ) * position );
    }

    //-------------------------------------------------------------------------

    public static double Lerp(
      double fromValue,
      double fromMin,
      double fromMax,
      double toMin,
      double toMax,
      bool clampToBounds = true )
    {
      if( clampToBounds )
      {
        if( fromValue < fromMin )
        {
          fromValue = fromMin;
        }
        else if( fromValue > fromMax )
        {
          fromValue = fromMax;
        }
      }

      double fromRange = ( fromMax - fromMin );
      double toRange = ( toMax - toMin );

      if( fromRange == 0.0 )
      {
        return toMin + ( toRange * 0.5 );
      }

      double normalisedValue = ( fromValue - fromMin ) / fromRange;

      return toMin + ( toRange * normalisedValue );
    }

    //-------------------------------------------------------------------------

    // Convert rads/sec to revs/min.

    public static double ConvertRpsToRpm( double rps )
    {
      return ( rps / TwoPI ) * 60.0;
    }

    //-------------------------------------------------------------------------

    // Convert revs/min to rads/sec.

    public static double ConvertRpmToRps( double rpm )
    {
      return ( rpm / 60.0 ) * TwoPI;
    }

    //-------------------------------------------------------------------------
  }
}
