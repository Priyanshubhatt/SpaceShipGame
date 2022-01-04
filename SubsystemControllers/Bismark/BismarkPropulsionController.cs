using Godot;
using System;

public class BismarkPropulsionController : AbstractPropulsionController
{
    BismarkSensorsController SensorsController {get{return parentShip.SensorsController as BismarkSensorsController;}}    
    BismarkNavigationController NavigationController {get{return parentShip.NavigationController as BismarkNavigationController;}}    
    BismarkDefenceController DefenceController {get{return parentShip.DefenceController as BismarkDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
