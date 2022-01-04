using Godot;
using System;
using System.Collections.Generic;

public class SSAnneSensorsController : AbstractSensorsController
{
    SSAnneNavigationController NavigationController {get{return parentShip.NavigationController as SSAnneNavigationController;}}    
    SSAnnePropulsionController PropulsionController {get{return parentShip.PropulsionController as SSAnnePropulsionController;}}    
    SSAnneDefenceController DefenceController {get{return parentShip.DefenceController as SSAnneDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
