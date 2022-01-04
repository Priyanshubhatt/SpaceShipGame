using Godot;
using System;
using System.Collections.Generic;

public class Thunderbird3NavigationController : AbstractNavigationController
{
    Thunderbird3SensorsController SensorsController {get{return parentShip.SensorsController as Thunderbird3SensorsController;}}    
    Thunderbird3PropulsionController PropulsionController {get{return parentShip.PropulsionController as Thunderbird3PropulsionController;}}    
    Thunderbird3DefenceController DefenceController {get{return parentShip.DefenceController as Thunderbird3DefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
