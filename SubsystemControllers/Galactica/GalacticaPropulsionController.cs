using Godot;
using System;

public class GalacticaPropulsionController : AbstractPropulsionController
{
    GalacticaSensorsController SensorsController {get{return parentShip.SensorsController as GalacticaSensorsController;}}    
    GalacticaNavigationController NavigationController {get{return parentShip.NavigationController as GalacticaNavigationController;}}    
    GalacticaDefenceController DefenceController {get{return parentShip.DefenceController as GalacticaDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
