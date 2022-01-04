using Godot;
using System;

public class EnterpriseDefenceController : AbstractDefenceController
{
    EnterpriseSensorsController SensorsController {get{return parentShip.SensorsController as EnterpriseSensorsController;}}
    EnterpriseNavigationController NavigationController {get{return parentShip.NavigationController as EnterpriseNavigationController;}}
    EnterprisePropulsionController PropulsionController {get{return parentShip.PropulsionController as EnterprisePropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
