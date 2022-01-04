using Godot;
using System;
using System.Collections.Generic;

public class PillarOfAutumnNavigationController : AbstractNavigationController
{
    PillarOfAutumnSensorsController SensorsController { get { return parentShip.SensorsController as PillarOfAutumnSensorsController; } }
    PillarOfAutumnPropulsionController PropulsionController { get { return parentShip.PropulsionController as PillarOfAutumnPropulsionController; } }
    PillarOfAutumnDefenceController DefenceController { get { return parentShip.DefenceController as PillarOfAutumnDefenceController; } }

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
       //Student code goes here
    }    

    public override void DebugDraw(Font font)
    {
       //Student code goes here
    }
}
