using Godot;
using System;

public class EnterprisePropulsionController : AbstractPropulsionController
{
    EnterpriseSensorsController SensorsController {get{return parentShip.SensorsController as EnterpriseSensorsController;}}    
    EnterpriseNavigationController NavigationController {get{return parentShip.NavigationController as EnterpriseNavigationController;}}    
    EnterpriseDefenceController DefenceController {get{return parentShip.DefenceController as EnterpriseDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
