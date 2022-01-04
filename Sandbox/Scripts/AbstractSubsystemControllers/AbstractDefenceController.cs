using Godot;
using System;

public abstract class AbstractDefenceController : AbstractSubsystemController
{
    public abstract void DefenceUpdate(ShipStatusInfo shipStatusInfo, TurretControls turretControls, float deltaTime);
    
}
