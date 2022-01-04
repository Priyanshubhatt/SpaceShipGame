using Godot;
using System;
using System.Collections.Generic;

public class BismarkNavigationController : AbstractNavigationController
{
    BismarkSensorsController SensorsController {get{return parentShip.SensorsController as BismarkSensorsController;}}    
    BismarkPropulsionController PropulsionController {get{return parentShip.PropulsionController as BismarkPropulsionController;}}    
    BismarkDefenceController DefenceController {get{return parentShip.DefenceController as BismarkDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
