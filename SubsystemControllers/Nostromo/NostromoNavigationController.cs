using Godot;
using System;
using System.Collections.Generic;

public class NostromoNavigationController : AbstractNavigationController
{
    NostromoSensorsController SensorsController {get{return parentShip.SensorsController as NostromoSensorsController;}}    
    NostromoPropulsionController PropulsionController {get{return parentShip.PropulsionController as NostromoPropulsionController;}}    
    NostromoDefenceController DefenceController {get{return parentShip.DefenceController as NostromoDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
