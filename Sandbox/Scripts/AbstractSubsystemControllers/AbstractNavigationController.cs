using Godot;
using System;

public abstract class AbstractNavigationController : AbstractSubsystemController
{
    public abstract void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime);    
}
