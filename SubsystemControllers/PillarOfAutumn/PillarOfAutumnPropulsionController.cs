using Godot;
using System;

public class PillarOfAutumnPropulsionController : AbstractPropulsionController
{
    PillarOfAutumnSensorsController SensorsController { get { return parentShip.SensorsController as PillarOfAutumnSensorsController; } }
    PillarOfAutumnNavigationController NavigationController { get { return parentShip.NavigationController as PillarOfAutumnNavigationController; } }
    PillarOfAutumnDefenceController DefenceController { get { return parentShip.DefenceController as PillarOfAutumnDefenceController; } }

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusterControls, float deltaTime)
    {
        //Student code goes here
    }
 
    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
