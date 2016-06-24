using System;

namespace GDVCore.Common.Graph
{
  abstract class Graph2d
  {
    //-------------------------------------------------------------------------

    public struct Point
    {
      public double x;
      public double y;

      public Point(
        double x = 0.0,
        double y = 0.0 )
      {
        this.x = x;
        this.y = y;
      }
    }

    //-------------------------------------------------------------------------

    private Point[] Points { get; set; } = new Point[ 0 ];

    //-------------------------------------------------------------------------

    public void AddPoint(
      double x,
      double y )
    {
      Point[] tmp = new Point[ Points.Length + 1 ];

      for( int i = 0; i < Points.Length; i++ )
      {
        tmp[ i ] = Points[ i ];
      }

      tmp[ Points.Length ] = new Point( x, y );

      Points = tmp;
    }

    //-------------------------------------------------------------------------

    public void SetPoint(
      int index,
      double x,
      double y,
      bool clampIndexToBounds = true )
    {
      // Clamping?
      if( clampIndexToBounds )
      {
        if( index < 0 )
        {
          index = 0;
        }
        else if( index >= Points.Length )
        {
          index = Points.Length - 1;
        }
      }

      // Check the index is in bounds.
      if( index < 0 || index >= Points.Length )
      {
        throw new IndexOutOfRangeException();
      }

      // Update the point.
      Points[ index ].x = x;
      Points[ index ].y = y;
    }

    //-------------------------------------------------------------------------

    public Point GetPoint(
      int index,
      bool clampIndexToBounds = true )
    {
      // Clamping?
      if( clampIndexToBounds )
      {
        if( index < 0 )
        {
          index = 0;
        }
        else if( index >= Points.Length )
        {
          index = Points.Length - 1;
        }
      }

      // Check the index is in bounds.
      if( index < 0 || index >= Points.Length )
      {
        throw new IndexOutOfRangeException();
      }

      // Return the point.
      return Points[ index ];
    }

    //-------------------------------------------------------------------------
    // Abstract methods.

    // Returns the Y value at the specified position on the X axis.
    public abstract double GetValueAtX( double xPosition );

    // Returns the X value at the specified position on the Y axis.
    public abstract double GetValueAtY( double yPosition );

    //-------------------------------------------------------------------------
  }
}