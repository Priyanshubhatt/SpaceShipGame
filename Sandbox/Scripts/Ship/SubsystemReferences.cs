using System;
using Godot;

public abstract class SubsystemReferences
{
    /*
    bool sensorsControllerEnabled = true;
    public event Action<bool> OnSensorsControllerEnabledChanged;
    public bool IsSensorsControllerEnabled {get{return sensorsControllerEnabled;} set{sensorsControllerEnabled = value; OnSensorsControllerEnabledChanged?.Invoke(sensorsControllerEnabled);}}
    

    bool navigationControllerEnabled = true;
    public event Action<bool> OnNavigationControllerEnabledChanged;
    public bool IsNavigationControllerEnabled {get{return navigationControllerEnabled;} set{navigationControllerEnabled = value; OnNavigationControllerEnabledChanged?.Invoke(navigationControllerEnabled);}}

    bool propulsionControllerEnabled = true;
    public event Action<bool> OnPropulsionControllerEnabledChanged;
    public bool IsPropulsionControllerEnabled {get{return propulsionControllerEnabled;} set{propulsionControllerEnabled = value; OnPropulsionControllerEnabledChanged?.Invoke(propulsionControllerEnabled);}}

    bool defenceControllerEnabled = true;
    public event Action<bool> OnDefenceControllerEnabledChanged;    
    public bool IsDefenceControllerEnabled {get{return defenceControllerEnabled;} set{defenceControllerEnabled = value; OnDefenceControllerEnabledChanged?.Invoke(defenceControllerEnabled);}}
    */
    /*
    //Subsystems
    public AbstractSensorsController Sensors { get; private set; }
    public AbstractNavigationController Navigation { get; private set; }
    public AbstractDefenceController Defence { get; private set; }
    public AbstractPropulsionController Propulsion { get; private set; }

    public SubsystemReferences(AbstractSensorsController sensors, AbstractNavigationController navigation, AbstractDefenceController defence, AbstractPropulsionController propulsion)
    {

        Sensors = sensors;
        Defence = defence;
        Navigation = navigation;
        Propulsion = propulsion;
    }
    */

    public abstract void ProcessPhysics(ShipStatusInfo shipStatusInfo, float deltaTime, ActiveSensors ActiveSensors, PassiveSensors passiveSensors,  GalaxyMapData galaxyMapData, ThrusterControls thrusterControls, TurretControls turretControls);
    
}