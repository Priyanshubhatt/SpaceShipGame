using Godot;
using System;

public class NormandyDefenceController : AbstractDefenceController
{
    NormandySensorsController SensorsController {get{return parentShip.SensorsController as NormandySensorsController;}}
    NormandyNavigationController NavigationController {get{return parentShip.NavigationController as NormandyNavigationController;}}
    NormandyPropulsionController PropulsionController {get{return parentShip.PropulsionController as NormandyPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
