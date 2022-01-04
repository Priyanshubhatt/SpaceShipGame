using Godot;
using System;

public class MilanoPropulsionController : AbstractPropulsionController
{
    MilanoSensorsController SensorsController {get{return parentShip.SensorsController as MilanoSensorsController;}}    
    MilanoNavigationController NavigationController {get{return parentShip.NavigationController as MilanoNavigationController;}}    
    MilanoDefenceController DefenceController {get{return parentShip.DefenceController as MilanoDefenceController;}}

    public override void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime)
    {
        //Student code goes here        
    }

    public override void DebugDraw(Font font)
    {
        //Student code goes here
    }
}
