using Godot;
using System;
using System.Collections.Generic;

public class YamatoNavigationController : AbstractNavigationController
{
    YamatoSensorsController SensorsController {get{return parentShip.SensorsController as YamatoSensorsController;}}    
    YamatoPropulsionController PropulsionController {get{return parentShip.PropulsionController as YamatoPropulsionController;}}    
    YamatoDefenceController DefenceController {get{return parentShip.DefenceController as YamatoDefenceController;}}

    public override void NavigationUpdate(ShipStatusInfo shipStatusInfo, GalaxyMapData galaxyMapData, float deltaTime)
    {
        //Student code goes here
    }   

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
