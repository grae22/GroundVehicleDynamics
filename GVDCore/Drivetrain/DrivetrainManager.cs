using System;
using System.Collections.Generic;

namespace GVDCore.Drivetrain
{
  class DrivetrainManager
  {
    //-------------------------------------------------------------------------

    private class ComponentNode
    {
      public DrivetrainComponent Component { get; set; } = null;
      public ComponentNode PreviousComponent { get; set; } = null;
      public List<ComponentNode> NextComponents { get; set; } = new List<ComponentNode>();

      public void AddNextNode( DrivetrainComponent component )
      {
        ComponentNode newNode = new ComponentNode();
        newNode.Component = component;
        newNode.PreviousComponent = this;

        NextComponents.Add( newNode );
      }
    }

    //-------------------------------------------------------------------------

    // 'First' nodes are at the 'head' of the drivetrain and will usually
    // have a chain of nodes following them.
    // Note: There may be multiple 'first' nodes, e.g. a drivetrain may have
    //       multiple engines.
    private List< ComponentNode > FirstNodes { get; set; } = new List<ComponentNode>();

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

      // Create the new component.
      DrivetrainComponent component =
        DrivetrainComponentFactory.CreateComponent< T >( componentName );

      // Adding as the 'first' component?
      if( afterComponentName == null )
      {
        ComponentNode node = new ComponentNode();
        node.Component = component;

        FirstNodes.Add( node );
      }
      else  // Find the component we need to add the new one after.
      {
        ComponentNode afterNode = FindComponentNode( afterComponentName );

        if( afterNode == null )
        {
          throw new Exception( "Failed to find node '" + afterComponentName + "'." );
        }

        afterNode.AddNextNode( component );
      }
    }

    //-------------------------------------------------------------------------

    private ComponentNode FindComponentNode( string componentName )
    {
      foreach( ComponentNode node in FirstNodes )
      {
        ComponentNode foundNode =
          FindComponentNodeRecursive(
            node,
            componentName );

        if( foundNode != null )
        {
          return foundNode;
        }
      }

      return null;
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
