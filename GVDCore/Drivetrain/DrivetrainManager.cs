using System;

namespace GVDCore.Drivetrain
{
  class DrivetrainManager
  {
    //-------------------------------------------------------------------------

    private class ComponentNode
    {
      public DrivetrainComponent Component { get; set; } = null;
      public ComponentNode PreviousComponent { get; set; } = null;
      public ComponentNode[] NextComponents { get; set; } = null;

      public void AddNextNode( DrivetrainComponent component )
      {
        ComponentNode newNode = new ComponentNode();
        newNode.Component = component;
        newNode.PreviousComponent = this;

        if( NextComponents == null )
        {
          NextComponents = new ComponentNode[ 1 ];
        }
        else
        {
          NextComponents = new ComponentNode[ NextComponents.Length + 1 ];
        }

        NextComponents[ NextComponents.Length - 1 ] = newNode;
      }
    }

    //-------------------------------------------------------------------------

    private ComponentNode FirstNode { get; set; } = null;

    //-------------------------------------------------------------------------

    // Adds a component to the drivetrain after the specified component. If
    // the specified 'after' component is null, then the component is added
    // as the 'first' component.

    public void AddComponent< T >(
      string afterComponentName,
      string componentName ) where T : DrivetrainComponent
    {
      // Null component specified?
      if( componentName == null ||
          componentName.Length == 0 )
      {
        throw new Exception( "Component name cannot be null or zero length." );
      }

      // 'After' component is null and there is already a 'first' component?
      if( afterComponentName == null &&
          FirstNode != null )
      {
        throw new Exception( "A 'first' component already exists." );
      }

      // Create the new component.
      DrivetrainComponent component =
        DrivetrainComponentFactory.CreateComponent< T >( componentName );

      // Adding as the 'first' component?
      if( afterComponentName == null )
      {
        FirstNode = new ComponentNode();
        FirstNode.Component = component;
      }
      else  // Find the component we need to add the new one after.
      {
        ComponentNode afterNode =
          FindComponentNodeRecursive(
            FirstNode,
            afterComponentName );

        if( afterNode == null )
        {
          throw new Exception( "Failed to find node '" + afterComponentName + "'." );
        }

        afterNode.AddNextNode( component );
      }
    }

    //-------------------------------------------------------------------------

    private ComponentNode FindComponentNodeRecursive(
      ComponentNode nodeToCheck,
      string componentNameToFind )
    {
      // Node to check is null?
      if( nodeToCheck == null )
      {
        return null;
      }

      // Is it this node?
      if( nodeToCheck.Component.Name == componentNameToFind )
      {
        return nodeToCheck;
      }

      // Check this component's 'next' nodes (if any).
      if( nodeToCheck.NextComponents != null )
      {
        foreach( ComponentNode node in nodeToCheck.NextComponents )
        {
          ComponentNode returnedNode =
            FindComponentNodeRecursive(
              node,
              componentNameToFind );

          // Found it?
          if( returnedNode != null )
          {
            return returnedNode;
          }
        }
      }

      return null;
    }

    //-------------------------------------------------------------------------
  }
}
