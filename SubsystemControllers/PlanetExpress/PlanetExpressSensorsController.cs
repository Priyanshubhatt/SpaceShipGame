using Godot;
using System;
using System.Collections.Generic;

public class PlanetExpressSensorsController : AbstractSensorsController
{
    PlanetExpressNavigationController NavigationController {get{return parentShip.NavigationController as PlanetExpressNavigationController;}}    
    PlanetExpressPropulsionController PropulsionController {get{return parentShip.PropulsionController as PlanetExpressPropulsionController;}}    
    PlanetExpressDefenceController DefenceController {get{return parentShip.DefenceController as PlanetExpressDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
