using System;

namespace GDVCore.Common.Rotator
{
  class FrictionlessRotator : Rotator
  {
    //-------------------------------------------------------------------------

    // Mass (kg).
    public double Mass { get; set; } = 0.0;

    // Radius (m).
    public double Radius { get; set; } = 0.0;
     
    // Rotational speed (rads/sec).
    private double AngularSpeed { get; set; } = 0.0;

    // RPM.
    private double Rpm { get; set; } = 0.0;

    // Total force that has been applied and not yet use to recalculate speed.
    private double PendingForce { get; set; } = 0.0;

    //-------------------------------------------------------------------------

    override public void Update( double deltaTime )
    {
      CalculateAngularSpeed();
    }

    //-------------------------------------------------------------------------

    override public void ApplyForce( double force )
    {
      PendingForce += force;
    }

    //-------------------------------------------------------------------------

    override public double GetRpm()
    {
      return Rpm;
    }

    //-------------------------------------------------------------------------

    override public double GetRps()
    {
      return AngularSpeed;
    }

    //-------------------------------------------------------------------------

    private void CalculateAngularSpeed()
    {
      if( Math.Abs( PendingForce ) > Double.MinValue )
      {
        // Calc torque.
        double T = PendingForce * Radius;

        // Calc moment of inertia.
        double I = ( Mass * ( Radius * Radius ) ) / 2.0;

        // Calc acceleration.
        double a = 0.0;

        if( Mass > 0.0 )
        {
          a = T / I;
        }

        // Calc new speed.
        AngularSpeed += a;

        // Reset pending force.
        PendingForce = 0.0;

        // Recalc RPM.
        CalculateRpm();
      }
    }

    //-------------------------------------------------------------------------

    private void CalculateRpm()
    {
      Rpm = GetRps() / ( Math.PI * 2.0 ) * 60.0;
    }

    //-------------------------------------------------------------------------
  }
}
