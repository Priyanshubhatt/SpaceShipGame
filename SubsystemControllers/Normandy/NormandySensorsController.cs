using Godot;
using System;
using System.Collections.Generic;

public class NormandySensorsController : AbstractSensorsController
{
    NormandyNavigationController NavigationController {get{return parentShip.NavigationController as NormandyNavigationController;}}    
    NormandyPropulsionController PropulsionController {get{return parentShip.PropulsionController as NormandyPropulsionController;}}    
    NormandyDefenceController DefenceController {get{return parentShip.DefenceController as NormandyDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
