using Godot;
using System;

public abstract class AbstractSensorsController : AbstractSubsystemController
{
    public abstract void SensorsUpdate(ShipStatusInfo shipStatusInfo, IActiveSensors activeSensors, PassiveSensors passiveSensors, float deltaTime);    
}
