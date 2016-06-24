namespace GVDCore.Drivetrain
{
  public abstract class DrivetrainComponent
  {
    //-------------------------------------------------------------------------

    public string Name { get; private set; }

    //-------------------------------------------------------------------------

    public DrivetrainComponent( string name )
    {
      Name = name;
    }

    //-------------------------------------------------------------------------

    public abstract double ProcessTorqueAndReturnSpeed(
      double deltaTime,
      double inputTorque,
      DrivetrainInputProvider inputProvider );

    //-------------------------------------------------------------------------
  }
}
