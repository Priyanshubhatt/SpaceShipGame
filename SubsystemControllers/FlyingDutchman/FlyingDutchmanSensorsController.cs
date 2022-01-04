using Godot;
using System;
using System.Collections.Generic;

public class FlyingDutchmanSensorsController : AbstractSensorsController
{
    FlyingDutchmanNavigationController NavigationController {get{return parentShip.NavigationController as FlyingDutchmanNavigationController;}}    
    FlyingDutchmanPropulsionController PropulsionController {get{return parentShip.PropulsionController as FlyingDutchmanPropulsionController;}}    
    FlyingDutchmanDefenceController DefenceController {get{return parentShip.DefenceController as FlyingDutchmanDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
