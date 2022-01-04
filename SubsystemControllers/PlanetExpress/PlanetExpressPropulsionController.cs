using Godot;
using System;

public class PlanetExpressPropulsionController : AbstractPropulsionController
{
    PlanetExpressSensorsController SensorsController {get{return parentShip.SensorsController as PlanetExpressSensorsController;}}    
    PlanetExpressNavigationController NavigationController {get{return parentShip.NavigationController as PlanetExpressNavigationController;}}    
    PlanetExpressDefenceController DefenceController {get{return parentShip.DefenceController as PlanetExpressDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
