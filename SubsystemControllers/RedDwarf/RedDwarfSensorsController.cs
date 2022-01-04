using Godot;
using System;
using System.Collections.Generic;

public class RedDwarfSensorsController : AbstractSensorsController
{
    RedDwarfNavigationController NavigationController {get{return parentShip.NavigationController as RedDwarfNavigationController;}}    
    RedDwarfPropulsionController PropulsionController {get{return parentShip.PropulsionController as RedDwarfPropulsionController;}}    
    RedDwarfDefenceController DefenceController {get{return parentShip.DefenceController as RedDwarfDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
