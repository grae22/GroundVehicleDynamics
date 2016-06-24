namespace GVDCore.Common.Rotator
{
  public abstract class Rotator
  {
    //-------------------------------------------------------------------------

    // Mass (kg).
    public double Mass { get; set; } = 0.0;

    // Radius (m).
    public double Radius { get; set; } = 0.0;

    //-------------------------------------------------------------------------

    public Rotator(
      double mass,
      double radius )
    {
      Mass = mass;
      Radius = radius;
    }

    //-------------------------------------------------------------------------
    // Abstract methods.

    // Called to update object's state.
    public abstract void Update( double deltaTime );

    // Called to apply a force on the object at the object's edge.
    public abstract void ApplyTangentForce( double force );

    // Called to apply a torque on the object.
    public abstract void ApplyTorque( double torque );

    // Returns rotation speed in radians per second.
    public abstract double GetRps();

    // Returns rotation speed in revolutions per minute.
    public abstract double GetRpm();

    //-------------------------------------------------------------------------
  }
}
