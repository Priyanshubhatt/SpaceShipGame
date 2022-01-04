using Godot;
using System;
using System.Collections.Generic;

public class BismarkSensorsController : AbstractSensorsController
{    
    BismarkNavigationController NavigationController {get{return parentShip.NavigationController as BismarkNavigationController;}}    
    BismarkPropulsionController PropulsionController {get{return parentShip.PropulsionController as BismarkPropulsionController;}}    
    BismarkDefenceController DefenceController {get{return parentShip.DefenceController as BismarkDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
