using Godot;
using System;
using System.Collections.Generic;

public class EventHorizonNavigationController : AbstractNavigationController
{
    EventHorizonSensorsController SensorsController {get{return parentShip.SensorsController as EventHorizonSensorsController;}}    
    EventHorizonPropulsionController PropulsionController {get{return parentShip.PropulsionController as EventHorizonPropulsionController;}}    
    EventHorizonDefenceController DefenceController {get{return parentShip.DefenceController as EventHorizonDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
