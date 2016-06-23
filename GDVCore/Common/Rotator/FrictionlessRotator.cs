using System;

namespace GDVCore.Common.Rotator
{
  class FrictionlessRotator : Rotator
  {
    //-------------------------------------------------------------------------

    // Rotational speed in rads/sec.
    private double AngularSpeed { get; set; } = 0.0;
    private double Rpm { get; set; } = 0.0;

    //-------------------------------------------------------------------------

    public override void Update( double deltaTime )
    {
      // TODO... this is probably wrong... too tired.
      Rpm = GetRps() / ( Math.PI * 2.0 ) / 60.0;
    }

    //-------------------------------------------------------------------------

    public override double GetRpm()
    {
      return 0.0;
    }

    //-------------------------------------------------------------------------

    public override double GetRps()
    {
      return AngularSpeed;
    }

    //-------------------------------------------------------------------------
  }
}
