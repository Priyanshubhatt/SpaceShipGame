using Godot;
using System;

public class YamatoDefenceController : AbstractDefenceController
{
    YamatoSensorsController SensorsController {get{return parentShip.SensorsController as YamatoSensorsController;}}
    YamatoNavigationController NavigationController {get{return parentShip.NavigationController as YamatoNavigationController;}}
    YamatoPropulsionController PropulsionController {get{return parentShip.PropulsionController as YamatoPropulsionController;}}    

    public override void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime)
    {
        //Student code goes here
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
