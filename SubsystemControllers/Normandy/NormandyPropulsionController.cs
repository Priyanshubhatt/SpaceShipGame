using Godot;
using System;

public class NormandyPropulsionController : AbstractPropulsionController
{
    NormandySensorsController SensorsController {get{return parentShip.SensorsController as NormandySensorsController;}}    
    NormandyNavigationController NavigationController {get{return parentShip.NavigationController as NormandyNavigationController;}}    
    NormandyDefenceController DefenceController {get{return parentShip.DefenceController as NormandyDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
