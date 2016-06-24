namespace GDVCore.Common.Rotator
{
  abstract class Rotator
  {
    //-------------------------------------------------------------------------

    // Called to update object's state.
    public abstract void Update( double deltaTime );

    // Called to apply a force on the object.
    public abstract void ApplyForce( double force );

    // Returns rotation speed in radians per second.
    public abstract double GetRps();

    // Returns rotation speed in revolutions per minute.
    public abstract double GetRpm();

    //-------------------------------------------------------------------------
  }
}
