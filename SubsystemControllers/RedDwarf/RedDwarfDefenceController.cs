using Godot;
using System;

public class RedDwarfDefenceController : AbstractDefenceController
{
    RedDwarfSensorsController SensorsController {get{return parentShip.SensorsController as RedDwarfSensorsController;}}
    RedDwarfNavigationController NavigationController {get{return parentShip.NavigationController as RedDwarfNavigationController;}}
    RedDwarfPropulsionController PropulsionController {get{return parentShip.PropulsionController as RedDwarfPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
