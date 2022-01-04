using Godot;
using System;

public class Thunderbird3DefenceController : AbstractDefenceController
{
    Thunderbird3SensorsController SensorsController {get{return parentShip.SensorsController as Thunderbird3SensorsController;}}
    Thunderbird3NavigationController NavigationController {get{return parentShip.NavigationController as Thunderbird3NavigationController;}}
    Thunderbird3PropulsionController PropulsionController {get{return parentShip.PropulsionController as Thunderbird3PropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
