using Godot;
using System;
using System.Collections.Generic;

public class NostromoSensorsController : AbstractSensorsController
{
    NostromoNavigationController NavigationController {get{return parentShip.NavigationController as NostromoNavigationController;}}    
    NostromoPropulsionController PropulsionController {get{return parentShip.PropulsionController as NostromoPropulsionController;}}    
    NostromoDefenceController DefenceController {get{return parentShip.DefenceController as NostromoDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
       //Student code goes here
    }
}
