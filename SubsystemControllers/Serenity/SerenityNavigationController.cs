using Godot;
using System;
using System.Collections.Generic;

public class SerenityNavigationController : AbstractNavigationController
{
    SerenitySensorsController SensorsController {get{return parentShip.SensorsController as SerenitySensorsController;}}    
    SerenityPropulsionController PropulsionController {get{return parentShip.PropulsionController as SerenityPropulsionController;}}    
    SerenityDefenceController DefenceController {get{return parentShip.DefenceController as SerenityDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
