using Godot;
using System;
using System.Collections.Generic;

public class MilanoNavigationController : AbstractNavigationController
{
    MilanoSensorsController SensorsController {get{return parentShip.SensorsController as MilanoSensorsController;}}    
    MilanoPropulsionController PropulsionController {get{return parentShip.PropulsionController as MilanoPropulsionController;}}    
    MilanoDefenceController DefenceController {get{return parentShip.DefenceController as MilanoDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
