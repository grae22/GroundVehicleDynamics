using System;
using GVDCore.Common.Maths;

namespace GVDCore.Common.Rotator
{
  public class SimpleRotator : Rotator
  {
    //-------------------------------------------------------------------------

    //-------------------------------------------------------------------------

    // Mass (kg).
    public double Mass { get; set; } = 0.0;

    // Radius (m).
    public double Radius { get; set; } = 0.0;

    // Coefficient of friction.
    public double CoefficientOfFriction { get; set; } = 0.0;

    // Rotational speed (rads/sec).
    private double AngularSpeed { get; set; } = 0.0;

    // RPM.
    private double Rpm { get; set; } = 0.0;

    // Total torque that has been applied and not yet used to recalculate speed.
    private double PendingTorque { get; set; } = 0.0;

    //-------------------------------------------------------------------------

    public SimpleRotator(
      double mass = 0.0,
      double radius = 0.0,
      double coefficientOfFriction = 0.0 )
    {
      Mass = mass;
      Radius = radius;
      CoefficientOfFriction = coefficientOfFriction;
    }

    //-------------------------------------------------------------------------

    public override void Update( double deltaTime )
    {
      CalculateAngularSpeed();
    }

    //-------------------------------------------------------------------------

    public override void ApplyTorque( double torque )
    {
      PendingTorque += torque;
    }

    //-------------------------------------------------------------------------

    public override void ApplyTangentForce( double force )
    {
      PendingTorque += ( force * Radius );
    }

    //-------------------------------------------------------------------------

    public override double GetRpm()
    {
      return Rpm;
    }

    //-------------------------------------------------------------------------

    public override double GetRps()
    {
      return AngularSpeed;
    }

    //-------------------------------------------------------------------------

    private void CalculateAngularSpeed()
    {
      if( Math.Abs( PendingTorque ) > double.Epsilon )
      {
        // Calc moment of inertia.
        double I = ( Mass * ( Radius * Radius ) ) / 2.0;

        // Calc acceleration.
        double a = 0.0;

        if( Mass > 0.0 )
        {
          a = PendingTorque / I;
        }

        // Reset pending torque var.
        PendingTorque = 0.0;

        // Calc new speed.
        AngularSpeed += a;
      }

      // Apply friction.
      AngularSpeed += -( AngularSpeed * CoefficientOfFriction );

      // Recalc RPM.
      Rpm = CommonMaths.ConvertRpsToRpm( AngularSpeed );
    }

    //-------------------------------------------------------------------------
  }
}
