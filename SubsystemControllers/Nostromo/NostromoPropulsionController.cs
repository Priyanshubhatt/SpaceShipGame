using Godot;
using System;

public class NostromoPropulsionController : AbstractPropulsionController
{
    NostromoSensorsController SensorsController { get { return parentShip.SensorsController as NostromoSensorsController; } }
    NostromoNavigationController NavigationController { get { return parentShip.NavigationController as NostromoNavigationController; } }
    NostromoDefenceController DefenceController { get { return parentShip.DefenceController as NostromoDefenceController; } }

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusterControls, float deltaTime)
    {
       //Student code goes here
    }

    public override void DebugDraw(Font debugFont)
    {
        //Student code goes here
    }
}
