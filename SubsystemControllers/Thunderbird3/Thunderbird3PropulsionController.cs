using Godot;
using System;

public class Thunderbird3PropulsionController : AbstractPropulsionController
{
    Thunderbird3SensorsController SensorsController {get{return parentShip.SensorsController as Thunderbird3SensorsController;}}    
    Thunderbird3NavigationController NavigationController {get{return parentShip.NavigationController as Thunderbird3NavigationController;}}    
    Thunderbird3DefenceController DefenceController {get{return parentShip.DefenceController as Thunderbird3DefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
