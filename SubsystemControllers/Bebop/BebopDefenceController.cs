using Godot;
using System;

public class BebopDefenceController : AbstractDefenceController
{
    BebopSensorsController SensorsController {get{return parentShip.SensorsController as BebopSensorsController;}}
    BebopNavigationController NavigationController {get{return parentShip.NavigationController as BebopNavigationController;}}
    BebopPropulsionController PropulsionController {get{return parentShip.PropulsionController as BebopPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here        
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}