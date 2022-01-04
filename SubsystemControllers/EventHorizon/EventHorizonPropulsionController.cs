using Godot;
using System;

public class EventHorizonPropulsionController : AbstractPropulsionController
{
    EventHorizonSensorsController SensorsController {get{return parentShip.SensorsController as EventHorizonSensorsController;}}    
    EventHorizonNavigationController NavigationController {get{return parentShip.NavigationController as EventHorizonNavigationController;}}    
    EventHorizonDefenceController DefenceController {get{return parentShip.DefenceController as EventHorizonDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
