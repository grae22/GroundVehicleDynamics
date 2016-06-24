using GDVCore.Common.Maths;

namespace GDVCore.Common.Graph
{
  class LinearGraph2d : Graph2d
  {
    //-------------------------------------------------------------------------

    public override double GetValueAtX( double xPosition )
    {
      // No points?
      if( Points.Length == 0 )
      {
        return 0.0;
      }

      // Only one point?
      if( Points.Length == 1 )
      {
        return Points[ 0 ].y;
      }

      // Find the point range in which the position falls.
      int index = -1;

      for( int i = 0; i < Points.Length - 1; i++ )
      {
        if( Points[ i ].x < xPosition &&
            xPosition <= Points[ i + 1 ].x )
        {
          index = i;
          break;
        }
      }

      // Not found? Maybe the position is before the first, or after the
      // last point.
      if( index == -1 )
      {
        if( xPosition <= Points[ 0 ].x )
        {
          return Points[ 0 ].y;
        }
        else if( xPosition > Points[ Points.Length - 1 ].x )
        {
          return Points[ Points.Length - 1 ].y;
        }
      }

      // Linearly interpolate between range's end points to find a value
      // for the position.
      return
        CommonMaths.Lerp(
          xPosition,
          Points[ index ].x, Points[ index + 1 ].x,
          Points[ index ].y, Points[ index + 1 ].y );
    }

    //-------------------------------------------------------------------------

    public override double GetValueAtY( double yPosition )
    {
      // No points?
      if( Points.Length == 0 )
      {
        return 0.0;
      }

      // Only one point?
      if( Points.Length == 1 )
      {
        return Points[ 0 ].x;
      }

      // Find the point range in which the position falls.
      int index = -1;

      for( int i = 0; i < Points.Length - 1; i++ )
      {
        if( Points[ i ].y < yPosition &&
            yPosition <= Points[ i + 1 ].y )
        {
          index = i;
          break;
        }
      }

      // Not found? Maybe the position is before the first, or after the
      // last point.
      if( index == -1 )
      {
        if( yPosition <= Points[ 0 ].y )
        {
          return Points[ 0 ].x;
        }
        else if( yPosition > Points[ Points.Length - 1 ].y )
        {
          return Points[ Points.Length - 1 ].x;
        }
      }

      // Linearly interpolate between range's end points to find a value
      // for the position.
      return
        CommonMaths.Lerp(
          yPosition,
          Points[ index ].y, Points[ index + 1 ].y,
          Points[ index ].x, Points[ index + 1 ].x );
    }

    //-------------------------------------------------------------------------
  }
}
