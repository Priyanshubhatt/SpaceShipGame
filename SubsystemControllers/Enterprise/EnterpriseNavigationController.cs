using Godot;
using System;
using System.Collections.Generic;

public class EnterpriseNavigationController : AbstractNavigationController
{
    EnterpriseSensorsController SensorsController {get{return parentShip.SensorsController as EnterpriseSensorsController;}}    
    EnterprisePropulsionController PropulsionController {get{return parentShip.PropulsionController as EnterprisePropulsionController;}}    
    EnterpriseDefenceController DefenceController {get{return parentShip.DefenceController as EnterpriseDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
