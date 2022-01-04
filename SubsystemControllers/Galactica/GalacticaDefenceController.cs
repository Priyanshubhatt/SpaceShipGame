using Godot;
using System;

public class GalacticaDefenceController : AbstractDefenceController
{
    GalacticaSensorsController SensorsController {get{return parentShip.SensorsController as GalacticaSensorsController;}}
    GalacticaNavigationController NavigationController {get{return parentShip.NavigationController as GalacticaNavigationController;}}
    GalacticaPropulsionController PropulsionController {get{return parentShip.PropulsionController as GalacticaPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
