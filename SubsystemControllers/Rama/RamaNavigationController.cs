using Godot;
using System;
using System.Collections.Generic;

public class RamaNavigationController : AbstractNavigationController
{
    RamaSensorsController SensorsController {get{return parentShip.SensorsController as RamaSensorsController;}}    
    RamaPropulsionController PropulsionController {get{return parentShip.PropulsionController as RamaPropulsionController;}}    
    RamaDefenceController DefenceController {get{return parentShip.DefenceController as RamaDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
