using Godot;
using System;

public class MilanoDefenceController : AbstractDefenceController
{
    MilanoSensorsController SensorsController {get{return parentShip.SensorsController as MilanoSensorsController;}}
    MilanoNavigationController NavigationController {get{return parentShip.NavigationController as MilanoNavigationController;}}
    MilanoPropulsionController PropulsionController {get{return parentShip.PropulsionController as MilanoPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here        
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
