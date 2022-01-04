using Godot;
using System;

public class BebopPropulsionController : AbstractPropulsionController
{
    BebopSensorsController SensorsController {get{return parentShip.SensorsController as BebopSensorsController;}}    
    BebopNavigationController NavigationController {get{return parentShip.NavigationController as BebopNavigationController;}}    
    BebopDefenceController DefenceController {get{return parentShip.DefenceController as BebopDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
