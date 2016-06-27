using GVDCore.Common.Rotator;
using GVDCore.Common.Graph;
using GVDCore.Common.Maths;

namespace GVDCore.Drivetrain.Component
{
  public class SimpleEngine : DrivetrainComponent
  {
    //-------------------------------------------------------------------------

    // Idle speed (rps).
    private double IdleSpeed { get; set; } = 0.0;

    // Graph used to look up power values.
    public Graph2d PowerCurve { get; set; } = null;

    // Rotator object used to model the crankshaft, when assigning a mass
    // one should probably include the mass of the flywheel.
    public Rotator Crankshaft { get; set; } = null;

    //-------------------------------------------------------------------------

    public double IdleRpm
    {
      get
      {
        return CommonMaths.ConvertRpsToRpm( IdleSpeed );
      }
      
      set
      {
        IdleSpeed = CommonMaths.ConvertRpmToRps( value );
      }
    }

    //-------------------------------------------------------------------------

    public SimpleEngine( string name )
    :
      this(
        name,
        0.0,
        null,
        null,
        null )
    {

    }

    //-------------------------------------------------------------------------

    public SimpleEngine(
      string name,
      double idleRpm = 0.0,
      Graph2d powerCurve = null,
      Graph2d torqueCurve = null,
      Rotator crankshaft = null )
    :
      base( name )
    {
      PowerCurve = ( powerCurve == null ? new LinearGraph2d() : powerCurve );
      Crankshaft = ( crankshaft == null ? new SimpleRotator() : crankshaft );
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

      // Figure out the power at idle.
      double idlePower =
        PowerCurve.GetValueAtX(
          CommonMaths.ConvertRpsToRpm( IdleSpeed ) );
      
      // Calculate the actual power by factoring in the accelerator.
      double power = ( maxPower * inputProvider.GetAcceleratorInput() );

      // Calculate torque.
      double crankshaftSpeed = Crankshaft.GetRps();
      double torque = 0.0;

      if( crankshaftSpeed < double.Epsilon )
      {
        torque = inputTorque;
      }
      else
      {
        torque = ( idlePower + power ) / crankshaftSpeed;
      }

      // Apply torque to the crankshaft and allow it to update.
      Crankshaft.ApplyTorque( torque );
      Crankshaft.Update( deltaTime );

      return Crankshaft.GetRps();
    }

    //-------------------------------------------------------------------------
  }
}
