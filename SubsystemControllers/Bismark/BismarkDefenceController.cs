using Godot;
using System;

public class BismarkDefenceController : AbstractDefenceController
{    
    BismarkSensorsController SensorsController {get{return parentShip.SensorsController as BismarkSensorsController;}}
    BismarkNavigationController NavigationController {get{return parentShip.NavigationController as BismarkNavigationController;}}
    BismarkPropulsionController PropulsionController {get{return parentShip.PropulsionController as BismarkPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
