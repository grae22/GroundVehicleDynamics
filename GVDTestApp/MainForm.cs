using System;
using System.Windows.Forms;
using System.Threading;
using GVDCore.Drivetrain;
using GVDCore.Drivetrain.Component;
using GVDCore.Common.Rotator;

namespace GVDTestApp
{
  public partial class MainForm : Form
  {
    //-------------------------------------------------------------------------

    private class InputProvider : DrivetrainInputProvider
    {
      public double AcceleratorInput { get; set; } = 0.0;

      public override double GetAcceleratorInput()
      {
        return AcceleratorInput;
      }
    }

    //-------------------------------------------------------------------------

    private Thread Runner { get; set; }
    private bool IsRunnerAlive { get; set; } = false;
    private Thread UiRunner { get; set; }
    private bool IsUiRunnerAlive { get; set; } = false;
    private SimpleEngine Engine { get; set; } = new SimpleEngine( "Engine" );
    private InputProvider Input { get; set; } = new InputProvider();

    //-------------------------------------------------------------------------

    public MainForm()
    {
      InitializeComponent();

      Engine.IdleRpm = 600.0;
      Engine.PowerCurve.AddPoint( Engine.IdleRpm, 0.4 );
      Engine.PowerCurve.AddPoint( 5000.0, 20.0 );
      Engine.Crankshaft = new SimpleRotator( 2.0, 0.1, 0.005 );

      Runner = new Thread( new ThreadStart( Run ) );
      Runner.Start();

      UiRunner = new Thread( new ThreadStart( UiRun ) );
      UiRunner.Start();
    }

    //-------------------------------------------------------------------------

    private void Run()
    {
      IsRunnerAlive = true;

      double scenarioTime = 0.0;
      double starterMotorTorque = 0.1;

      while( IsRunnerAlive )
      {
        Engine.ProcessTorqueAndReturnSpeed(
          0.002,
          starterMotorTorque,
          Input );

        scenarioTime += 0.002;

        if( scenarioTime > 0.5 )
        {
          starterMotorTorque = 0.0;
        }

        Thread.Sleep( 2 );
      }
    }

    //-------------------------------------------------------------------------

    private void UiRun()
    {
      IsUiRunnerAlive = true;

      UpdateUiDelegate updateUi = new UpdateUiDelegate( UpdateUi );

      while( IsUiRunnerAlive )
      {
        try
        {
          Invoke( updateUi );

          Thread.Sleep( 50 );
        }
        catch( Exception )
        {
          // Ignore.
        }
      }
    }

    //-------------------------------------------------------------------------

    private void MainForm_FormClosed(
      object sender,
      FormClosedEventArgs e )
    {
      IsRunnerAlive = false;
      Runner.Abort();
      Runner.Join();

      IsUiRunnerAlive = false;
      UiRunner.Abort();
      UiRunner.Join();
    }

    //-------------------------------------------------------------------------

    private delegate void UpdateUiDelegate();

    private void UpdateUi()
    {
      uiEngineRpm.Text = Engine.Crankshaft.GetRpm().ToString( "0.00" );

      Input.AcceleratorInput = uiAccelerator.Value * 0.01;
    }

    //-------------------------------------------------------------------------
  }
}
