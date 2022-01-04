using Godot;
using System;

public class Turret : Node2D
{
    [Export] int tubeCount = 4;
    [Export] float launchSpeed = 100f;
    [Export] PackedScene torpedoScene;

    public TurretControls TurretControls { get; private set; }

    ColonyShip parentShip;

    public float CooldownDuration {get; private set;} = 3f;
    float[] cooldowns;

    public float TorpedoSpeed { get { return launchSpeed; } }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        parentShip = GetNode<ColonyShip>("../");
        TurretControls = new TurretControls(this);

        cooldowns = new float[tubeCount];

        TurretControls.OnTubeTriggered += HandleTubeTriggered;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        LookAt(TurretControls.aimTo);

        for (int i = 0; i < tubeCount; i++)
        {
            cooldowns[i] = Mathf.Max(0, cooldowns[i] - delta);
        }
    }

    public float GetTubeCooldown(int tubeIndex)
    {
        if (tubeIndex < 0 || tubeIndex >= cooldowns.Length)
        {
            return -1f;
        }

        return cooldowns[tubeIndex];
    }

    void FireMissile(float fuseDuration)
    {
        LookAt(TurretControls.aimTo);

        var newTorpedo = torpedoScene.Instance() as Torpedo;
        newTorpedo.GlobalPosition = GlobalPosition;
        newTorpedo.GlobalRotation = GlobalRotation;
        newTorpedo.LinearVelocity = (Vector2.Right * Torpedo.LaunchSpeed).Rotated(GlobalRotation);
        newTorpedo.OwnedByShip = parentShip;
        newTorpedo.FuseDuration = fuseDuration;
        parentShip.TorpedoesFired++;
        GetNode("../../").AddChild(newTorpedo);
    }

    void HandleTubeTriggered(int tubeIndex, float fuseDuration)
    {
        if(tubeIndex < 0 || tubeIndex >= tubeCount)
            return;

        if (cooldowns[tubeIndex] <= 0f)
        {
            FireMissile(fuseDuration);
            cooldowns[tubeIndex] = CooldownDuration;
        }
    }
}
