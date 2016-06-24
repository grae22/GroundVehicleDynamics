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
      double xRange = ( Points[ index + 1 ].x - Points[ index ].x );

      if( xRange == 0.0 )
      {
        return Points[ index ].y;
      }

      double normalisedPosition = ( xPosition - Points[ index ].x ) / xRange;
      double yRange = ( Points[ index + 1 ].y - Points[ index ].y );

      return Points[ index ].y + ( yRange * normalisedPosition );
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
      double yRange = ( Points[ index + 1 ].y - Points[ index ].y );

      if( yRange == 0.0 )
      {
        return Points[ index ].x;
      }

      double normalisedPosition = ( yPosition - Points[ index ].y ) / yRange;
      double xRange = ( Points[ index + 1 ].x - Points[ index ].x );

      return Points[ index ].x + ( xRange * normalisedPosition );
    }

    //-------------------------------------------------------------------------
  }
}
