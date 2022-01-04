using Godot;
using System;
using System.Collections.Generic;

public class BebopNavigationController : AbstractNavigationController
{
    BebopSensorsController SensorsController {get{return parentShip.SensorsController as BebopSensorsController;}}    
    BebopPropulsionController PropulsionController {get{return parentShip.PropulsionController as BebopPropulsionController;}}    
    BebopDefenceController DefenceController {get{return parentShip.DefenceController as BebopDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}