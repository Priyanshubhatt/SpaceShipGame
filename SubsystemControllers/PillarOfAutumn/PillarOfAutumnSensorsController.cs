using Godot;
using System;
using System.Collections.Generic;

public class PillarOfAutumnSensorsController : AbstractSensorsController
{
    PillarOfAutumnNavigationController NavigationController { get { return parentShip.NavigationController as PillarOfAutumnNavigationController; } }
    PillarOfAutumnPropulsionController PropulsionController { get { return parentShip.PropulsionController as PillarOfAutumnPropulsionController; } }
    PillarOfAutumnDefenceController DefenceController { get { return parentShip.DefenceController as PillarOfAutumnDefenceController; } }

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
