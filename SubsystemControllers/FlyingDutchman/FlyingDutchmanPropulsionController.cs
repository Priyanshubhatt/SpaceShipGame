using Godot;
using System;

public class FlyingDutchmanPropulsionController : AbstractPropulsionController
{
    FlyingDutchmanSensorsController SensorsController {get{return parentShip.SensorsController as FlyingDutchmanSensorsController;}}    
    FlyingDutchmanNavigationController NavigationController {get{return parentShip.NavigationController as FlyingDutchmanNavigationController;}}    
    FlyingDutchmanDefenceController DefenceController {get{return parentShip.DefenceController as FlyingDutchmanDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
