using Godot;
using System;
using System.Collections.Generic;

public class SerenitySensorsController : AbstractSensorsController
{
    SerenityNavigationController NavigationController {get{return parentShip.NavigationController as SerenityNavigationController;}}    
    SerenityPropulsionController PropulsionController {get{return parentShip.PropulsionController as SerenityPropulsionController;}}    
    SerenityDefenceController DefenceController {get{return parentShip.DefenceController as SerenityDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
