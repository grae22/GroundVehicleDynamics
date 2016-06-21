namespace GDVCore.Drivetrain
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

    public abstract double Process( double inputTorque );

    //-------------------------------------------------------------------------
  }
}
