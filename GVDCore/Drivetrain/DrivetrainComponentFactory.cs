using System;

namespace GVDCore.Drivetrain
{
  class DrivetrainComponentFactory
  {
    //-------------------------------------------------------------------------

    public static T CreateComponent<T>( string name ) where T : DrivetrainComponent
    {
      object[] args = { name };

      T component = (T)Activator.CreateInstance( typeof( T ), args );

      if( component == null )
      {
        throw new Exception(
          "Failed to instantiate object named '" + name + "' " +
          "of type '" + typeof( T ).FullName + "'." );
      }

      return component;
    }

    //-------------------------------------------------------------------------
  }
}
