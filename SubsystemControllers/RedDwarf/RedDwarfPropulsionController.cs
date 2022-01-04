using Godot;
using System;

public class RedDwarfPropulsionController : AbstractPropulsionController
{
    RedDwarfSensorsController SensorsController {get{return parentShip.SensorsController as RedDwarfSensorsController;}}    
    RedDwarfNavigationController NavigationController {get{return parentShip.NavigationController as RedDwarfNavigationController;}}    
    RedDwarfDefenceController DefenceController {get{return parentShip.DefenceController as RedDwarfDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
