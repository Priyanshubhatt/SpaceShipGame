using Godot;
using System;
using System.Collections.Generic;

public class FlyingDutchmanNavigationController : AbstractNavigationController
{
    FlyingDutchmanSensorsController SensorsController {get{return parentShip.SensorsController as FlyingDutchmanSensorsController;}}    
    FlyingDutchmanPropulsionController PropulsionController {get{return parentShip.PropulsionController as FlyingDutchmanPropulsionController;}}    
    FlyingDutchmanDefenceController DefenceController {get{return parentShip.DefenceController as FlyingDutchmanDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
