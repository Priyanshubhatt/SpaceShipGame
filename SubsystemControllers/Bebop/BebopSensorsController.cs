using Godot;
using System;
using System.Collections.Generic;

public class BebopSensorsController : AbstractSensorsController
{
    BebopNavigationController NavigationController {get{return parentShip.NavigationController as BebopNavigationController;}}    
    BebopPropulsionController PropulsionController {get{return parentShip.PropulsionController as BebopPropulsionController;}}    
    BebopDefenceController DefenceController {get{return parentShip.DefenceController as BebopDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
