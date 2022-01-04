using Godot;
using System;
using System.Collections.Generic;

public class Thunderbird3SensorsController : AbstractSensorsController
{
    Thunderbird3NavigationController NavigationController {get{return parentShip.NavigationController as Thunderbird3NavigationController;}}    
    Thunderbird3PropulsionController PropulsionController {get{return parentShip.PropulsionController as Thunderbird3PropulsionController;}}    
    Thunderbird3DefenceController DefenceController {get{return parentShip.DefenceController as Thunderbird3DefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
