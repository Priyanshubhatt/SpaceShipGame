using Godot;
using System;

public class PlanetExpressDefenceController : AbstractDefenceController
{
    PlanetExpressSensorsController SensorsController {get{return parentShip.SensorsController as PlanetExpressSensorsController;}}
    PlanetExpressNavigationController NavigationController {get{return parentShip.NavigationController as PlanetExpressNavigationController;}}
    PlanetExpressPropulsionController PropulsionController {get{return parentShip.PropulsionController as PlanetExpressPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
