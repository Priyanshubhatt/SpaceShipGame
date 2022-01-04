using Godot;
using System;

public class RamaDefenceController : AbstractDefenceController
{
    RamaSensorsController SensorsController {get{return parentShip.SensorsController as RamaSensorsController;}}
    RamaNavigationController NavigationController {get{return parentShip.NavigationController as RamaNavigationController;}}
    RamaPropulsionController PropulsionController {get{return parentShip.PropulsionController as RamaPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
