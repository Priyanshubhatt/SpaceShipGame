using Godot;
using System;
using System.Collections.Generic;

public class RamaSensorsController : AbstractSensorsController
{
    RamaNavigationController NavigationController {get{return parentShip.NavigationController as RamaNavigationController;}}    
    RamaPropulsionController PropulsionController {get{return parentShip.PropulsionController as RamaPropulsionController;}}    
    RamaDefenceController DefenceController {get{return parentShip.DefenceController as RamaDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
