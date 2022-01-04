using Godot;
using System;
using System.Collections.Generic;

public class YamatoSensorsController : AbstractSensorsController
{
    YamatoNavigationController NavigationController {get{return parentShip.NavigationController as YamatoNavigationController;}}    
    YamatoPropulsionController PropulsionController {get{return parentShip.PropulsionController as YamatoPropulsionController;}}    
    YamatoDefenceController DefenceController {get{return parentShip.DefenceController as YamatoDefenceController;}}

    public override void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime)
    {
        //Student code goes here   
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
