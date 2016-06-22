namespace GDVCore.Drivetrain
{
  class SimpleEngine : DrivetrainComponent
  {
    //-------------------------------------------------------------------------

    public SimpleEngine( string name )
    :
      base( name )
    {

    }

    //-------------------------------------------------------------------------

    public override double ProcessTorqueAndReturnSpeed(
      double inputTorque,
      DrivetrainInputProvider inputProvider )
    {
      return 0.0;
    }

    //-------------------------------------------------------------------------
  }
}
