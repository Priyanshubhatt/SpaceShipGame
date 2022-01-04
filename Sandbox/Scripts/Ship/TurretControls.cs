using System;
using Godot;
public class TurretControls
{
    private readonly Turret parentTurret;

    public TurretControls(Turret parentTurret)
    {
        this.parentTurret = parentTurret;
    }

    public Vector2 aimTo = new Vector2();

    public float GetTubeCooldown(int tubeIndex)
    {
        return parentTurret.GetTubeCooldown(tubeIndex);
    }

    public event Action<int,float> OnTubeTriggered; //tubeIndex, fuseDuration

    public void TriggerTube(int tubeIndex, float fuseDuration)
    {
        OnTubeTriggered?.Invoke(tubeIndex, fuseDuration);
    }
}
