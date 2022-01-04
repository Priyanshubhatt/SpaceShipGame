using Godot;
using System;

public class RamaPropulsionController : AbstractPropulsionController
{
    RamaSensorsController SensorsController { get { return parentShip.SensorsController as RamaSensorsController; } }
    RamaNavigationController NavigationController { get { return parentShip.NavigationController as RamaNavigationController; } }
    RamaDefenceController DefenceController { get { return parentShip.DefenceController as RamaDefenceController; } }

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
