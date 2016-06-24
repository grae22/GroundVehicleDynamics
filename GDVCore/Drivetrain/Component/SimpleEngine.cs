using GDVCore.Common.Rotator;
using GDVCore.Common.Graph;

namespace GDVCore.Drivetrain.Component
{
  class SimpleEngine : DrivetrainComponent
  {
    //-------------------------------------------------------------------------

    // Graph used to look up power values.
    public Graph2d PowerCurve { get; set; }

    // Graph used to look up torque values.
    public Graph2d TorqueCurve { get; set; }

    // Rotator object used to model the flywheel.
    public Rotator Flywheel { get; set; }

    //-------------------------------------------------------------------------

    public SimpleEngine(
      string name,
      Graph2d powerCurve = null,
      Graph2d torqueCurve = null,
      Rotator flywheel = null )
    :
      base( name )
    {
      PowerCurve = ( powerCurve == null ? new LinearGraph2d() : powerCurve );
      TorqueCurve = ( torqueCurve == null ? new LinearGraph2d() : torqueCurve );
      Flywheel = ( flywheel == null ? new FrictionlessRotator() : flywheel );
    }

    //-------------------------------------------------------------------------

    public override double ProcessTorqueAndReturnSpeed(
      double deltaTime,
      double inputTorque,
      DrivetrainInputProvider inputProvider )
    {
      //Flywheel.ApplyTorque(

      Flywheel.Update( deltaTime );

      return Flywheel.GetRps();
    }

    //-------------------------------------------------------------------------
  }
}
