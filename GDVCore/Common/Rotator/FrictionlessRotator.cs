﻿using System;

namespace GDVCore.Common.Rotator
{
  class FrictionlessRotator : Rotator
  {
    //-------------------------------------------------------------------------

    // Rotational speed (rads/sec).
    private double AngularSpeed { get; set; } = 0.0;

    // RPM.
    private double Rpm { get; set; } = 0.0;

    // Total torque that has been applied and not yet used to recalculate speed.
    private double PendingTorque { get; set; } = 0.0;

    //-------------------------------------------------------------------------

    public FrictionlessRotator(
      double mass = 0.0,
      double radius = 0.0 )
    :
      base( mass, radius )
    {

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
      if( Math.Abs( PendingTorque ) > Double.MinValue )
      {
        // Calc moment of inertia.
        double I = ( Mass * ( Radius * Radius ) ) / 2.0;

        // Calc acceleration.
        double a = 0.0;

        if( Mass > 0.0 )
        {
          a = PendingTorque / I;
        }

        // Calc new speed.
        AngularSpeed += a;

        // Reset pending torque var.
        PendingTorque = 0.0;

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
