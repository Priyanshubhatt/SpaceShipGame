using Godot;
using System;
using System.Collections.Generic;

public class EnterpriseSensorsController : AbstractSensorsController
{
    EnterpriseNavigationController NavigationController {get{return parentShip.NavigationController as EnterpriseNavigationController;}}    
    EnterprisePropulsionController PropulsionController {get{return parentShip.PropulsionController as EnterprisePropulsionController;}}    
    EnterpriseDefenceController DefenceController {get{return parentShip.DefenceController as EnterpriseDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
