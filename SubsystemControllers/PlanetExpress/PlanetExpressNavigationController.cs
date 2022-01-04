using Godot;
using System;
using System.Collections.Generic;

public class PlanetExpressNavigationController : AbstractNavigationController
{
    PlanetExpressSensorsController SensorsController {get{return parentShip.SensorsController as PlanetExpressSensorsController;}}    
    PlanetExpressPropulsionController PropulsionController {get{return parentShip.PropulsionController as PlanetExpressPropulsionController;}}    
    PlanetExpressDefenceController DefenceController {get{return parentShip.DefenceController as PlanetExpressDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
