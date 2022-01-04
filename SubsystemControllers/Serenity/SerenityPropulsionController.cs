using Godot;
using System;

public class SerenityPropulsionController : AbstractPropulsionController
{
    SerenitySensorsController SensorsController {get{return parentShip.SensorsController as SerenitySensorsController;}}    
    SerenityNavigationController NavigationController {get{return parentShip.NavigationController as SerenityNavigationController;}}    
    SerenityDefenceController DefenceController {get{return parentShip.DefenceController as SerenityDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
