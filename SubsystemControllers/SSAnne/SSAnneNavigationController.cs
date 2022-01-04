using Godot;
using System;
using System.Collections.Generic;

public class SSAnneNavigationController : AbstractNavigationController
{
    SSAnneSensorsController SensorsController {get{return parentShip.SensorsController as SSAnneSensorsController;}}    
    SSAnnePropulsionController PropulsionController {get{return parentShip.PropulsionController as SSAnnePropulsionController;}}    
    SSAnneDefenceController DefenceController {get{return parentShip.DefenceController as SSAnneDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
