using Godot;
using System;

public abstract class AbstractPropulsionController : AbstractSubsystemController
{
    public abstract void PropulsionUpdate(ShipStatusInfo shipStatusInfo, ThrusterControls thrusters, float deltaTime);
}
