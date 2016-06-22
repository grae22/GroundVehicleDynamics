namespace GDVCore.Drivetrain
{
  abstract class DrivetrainComponent
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
      double inputTorque,
      DrivetrainInputProvider inputProvider );

    //-------------------------------------------------------------------------
  }
}
