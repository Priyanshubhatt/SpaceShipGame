using Godot;
using System;
using System.Collections.Generic;

public class GalacticaNavigationController : AbstractNavigationController
{
    GalacticaSensorsController SensorsController {get{return parentShip.SensorsController as GalacticaSensorsController;}}    
    GalacticaPropulsionController PropulsionController {get{return parentShip.PropulsionController as GalacticaPropulsionController;}}    
    GalacticaDefenceController DefenceController {get{return parentShip.DefenceController as GalacticaDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
