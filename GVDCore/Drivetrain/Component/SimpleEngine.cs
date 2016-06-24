using GVDCore.Common.Rotator;
using GVDCore.Common.Graph;

namespace GVDCore.Drivetrain.Component
{
  public class SimpleEngine : DrivetrainComponent
  {
    //-------------------------------------------------------------------------

    // Graph used to look up power values.
    public Graph2d PowerCurve { get; set; }

    // Graph used to look up torque values.
    public Graph2d TorqueCurve { get; set; }

    // Rotator object used to model the crankshaft, when assigning a mass
    // one should probably include the mass of the flywheel.
    public Rotator Crankshaft { get; set; }

    //-------------------------------------------------------------------------

    public SimpleEngine(
      string name,
      Graph2d powerCurve = null,
      Graph2d torqueCurve = null,
      Rotator crankshaft = null )
    :
      base( name )
    {
      PowerCurve = ( powerCurve == null ? new LinearGraph2d() : powerCurve );
      TorqueCurve = ( torqueCurve == null ? new LinearGraph2d() : torqueCurve );
      Crankshaft = ( crankshaft == null ? new FrictionlessRotator() : crankshaft );
    }

    //-------------------------------------------------------------------------

    // 'inputTorque' : Starter motor?

    public override double ProcessTorqueAndReturnSpeed(
      double deltaTime,
      double inputTorque,
      DrivetrainInputProvider inputProvider )
    {
      // Figure out using our current engine speed what the max power we
      // can generate is.
      double maxPower = PowerCurve.GetValueAtX( Crankshaft.GetRpm() );
      
      // Calculate the actual power by factoring in the accelerator.
      double power = ( maxPower * inputProvider.GetAcceleratorInput() );

      // Calculate torque and add it to the input torque.
      double crankshaftSpeed = Crankshaft.GetRps();

      if( crankshaftSpeed != 0.0 )
      {
        inputTorque += power / crankshaftSpeed;
      }

      // Apply torque to the crankshaft and allow it to update.
      Crankshaft.ApplyTorque( inputTorque );
      Crankshaft.Update( deltaTime );

      return Crankshaft.GetRps();
    }

    //-------------------------------------------------------------------------
  }
}
