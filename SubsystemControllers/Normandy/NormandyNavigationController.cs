using Godot;
using System;
using System.Collections.Generic;

public class NormandyNavigationController : AbstractNavigationController
{
    NormandySensorsController SensorsController {get{return parentShip.SensorsController as NormandySensorsController;}}    
    NormandyPropulsionController PropulsionController {get{return parentShip.PropulsionController as NormandyPropulsionController;}}    
    NormandyDefenceController DefenceController {get{return parentShip.DefenceController as NormandyDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
