using Godot;
using System;
using System.Collections.Generic;

public class RedDwarfNavigationController : AbstractNavigationController
{
    RedDwarfSensorsController SensorsController {get{return parentShip.SensorsController as RedDwarfSensorsController;}}    
    RedDwarfPropulsionController PropulsionController {get{return parentShip.PropulsionController as RedDwarfPropulsionController;}}    
    RedDwarfDefenceController DefenceController {get{return parentShip.DefenceController as RedDwarfDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
