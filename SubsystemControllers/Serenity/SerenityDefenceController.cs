using Godot;
using System;

public class SerenityDefenceController : AbstractDefenceController
{
    SerenitySensorsController SensorsController {get{return parentShip.SensorsController as SerenitySensorsController;}}
    SerenityNavigationController NavigationController {get{return parentShip.NavigationController as SerenityNavigationController;}}
    SerenityPropulsionController PropulsionController {get{return parentShip.PropulsionController as SerenityPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
