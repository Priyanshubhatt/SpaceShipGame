using Godot;
using System;

public class SSAnnePropulsionController : AbstractPropulsionController
{
    SSAnneSensorsController SensorsController {get{return parentShip.SensorsController as SSAnneSensorsController;}}    
    SSAnneNavigationController NavigationController {get{return parentShip.NavigationController as SSAnneNavigationController;}}    
    SSAnneDefenceController DefenceController {get{return parentShip.DefenceController as SSAnneDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
