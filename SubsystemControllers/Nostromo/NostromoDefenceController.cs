using Godot;
using System;
using System.Collections.Generic;

public class NostromoDefenceController : AbstractDefenceController
{
    NostromoSensorsController SensorsController { get { return parentShip.SensorsController as NostromoSensorsController; } }
    NostromoNavigationController NavigationController { get { return parentShip.NavigationController as NostromoNavigationController; } }
    NostromoPropulsionController PropulsionController { get { return parentShip.PropulsionController as NostromoPropulsionController; } }

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
