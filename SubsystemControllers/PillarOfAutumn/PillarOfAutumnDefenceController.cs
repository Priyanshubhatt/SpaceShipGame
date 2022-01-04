using Godot;
using System;
using System.Collections.Generic;

public class PillarOfAutumnDefenceController : AbstractDefenceController
{
    PillarOfAutumnSensorsController SensorsController { get { return parentShip.SensorsController as PillarOfAutumnSensorsController; } }
    PillarOfAutumnNavigationController NavigationController { get { return parentShip.NavigationController as PillarOfAutumnNavigationController; } }
    PillarOfAutumnPropulsionController PropulsionController { get { return parentShip.PropulsionController as PillarOfAutumnPropulsionController; } }

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
       //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
