using GDVCore.Common.Rotator;

namespace GDVCore.Drivetrain.Component
{
  class SimpleEngine : DrivetrainComponent
  {
    //-------------------------------------------------------------------------

    private Rotator Flywheel { get; set; }

    //-------------------------------------------------------------------------

    public double FlywheelMass
    {
      get
      {
        return Flywheel.Mass;
      }

      set
      {
        Flywheel.Mass = value;
      }
    }

    //-------------------------------------------------------------------------

    public double FlywheelRadius
    {
      get
      {
        return Flywheel.Radius;
      }

      set
      {
        Flywheel.Radius = value;
      }
    }

    //-------------------------------------------------------------------------

    public SimpleEngine(
      string name,
      Rotator flywheel = null )
    :
      base( name )
    {
      Flywheel = ( flywheel == null ? new FrictionlessRotator() : flywheel );
    }

    //-------------------------------------------------------------------------

    public override double ProcessTorqueAndReturnSpeed(
      double deltaTime,
      double inputTorque,
      DrivetrainInputProvider inputProvider )
    {
      Flywheel.Update( deltaTime );

      return Flywheel.GetRps();
    }

    //-------------------------------------------------------------------------
  }
}
