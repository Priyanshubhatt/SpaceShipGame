using Godot;
using System;
using System.Collections.Generic;

public class GalacticaSensorsController : AbstractSensorsController
{
    GalacticaNavigationController NavigationController {get{return parentShip.NavigationController as GalacticaNavigationController;}}    
    GalacticaPropulsionController PropulsionController {get{return parentShip.PropulsionController as GalacticaPropulsionController;}}    
    GalacticaDefenceController DefenceController {get{return parentShip.DefenceController as GalacticaDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
