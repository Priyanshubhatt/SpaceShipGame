using Godot;
using System;
using System.Collections.Generic;

public class MilanoSensorsController : AbstractSensorsController
{
    MilanoNavigationController NavigationController {get{return parentShip.NavigationController as MilanoNavigationController;}}    
    MilanoPropulsionController PropulsionController {get{return parentShip.PropulsionController as MilanoPropulsionController;}}    
    MilanoDefenceController DefenceController {get{return parentShip.DefenceController as MilanoDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
