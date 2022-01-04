using Godot;
using System;

public class YamatoPropulsionController : AbstractPropulsionController
{
    YamatoSensorsController SensorsController {get{return parentShip.SensorsController as YamatoSensorsController;}}    
    YamatoNavigationController NavigationController {get{return parentShip.NavigationController as YamatoNavigationController;}}    
    YamatoDefenceController DefenceController {get{return parentShip.DefenceController as YamatoDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
