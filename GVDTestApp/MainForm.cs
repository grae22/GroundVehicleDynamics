using System.Windows.Forms;
using System.Threading;
using GVDCore.Drivetrain;
using GVDCore.Drivetrain.Component;
using System;

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

      Engine.PowerCurve.AddPoint( 800.0, 1000.0 );
      Engine.PowerCurve.AddPoint( 1000.0, 2000.0 );
      Engine.Crankshaft.Mass = 10.0;
      Engine.Crankshaft.Radius = 0.10;

      Runner = new Thread( new ThreadStart( Run ) );
      Runner.Start();

      UiRunner = new Thread( new ThreadStart( UiRun ) );
      UiRunner.Start();
    }

    //-------------------------------------------------------------------------

    private void Run()
    {
      IsRunnerAlive = true;

      while( IsRunnerAlive )
      {
        Engine.ProcessTorqueAndReturnSpeed( 0.002, 10.0, Input );

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
        Invoke( updateUi );

        Thread.Sleep( 100 );
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
      uiEngineRpm.Text = Engine.Crankshaft.GetRpm().ToString();
    }

    //-------------------------------------------------------------------------
  }
}
