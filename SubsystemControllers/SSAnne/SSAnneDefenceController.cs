using Godot;
using System;

public class SSAnneDefenceController : AbstractDefenceController
{
    SSAnneSensorsController SensorsController {get{return parentShip.SensorsController as SSAnneSensorsController;}}
    SSAnneNavigationController NavigationController {get{return parentShip.NavigationController as SSAnneNavigationController;}}
    SSAnnePropulsionController PropulsionController {get{return parentShip.PropulsionController as SSAnnePropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
