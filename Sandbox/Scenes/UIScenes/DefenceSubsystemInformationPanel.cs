using Godot;
using System;

public class DefenceSubsystemInformationPanel : PanelContainer
{
    //Internal
    Label totalCollisionsLabel;
    Label collisionDamageLabel;
    ProgressBar tube0ProgressBar;
    ProgressBar tube1ProgressBar;
    ProgressBar tube2ProgressBar;
    ProgressBar tube3ProgressBar;

    ColonyShip focusShip;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        totalCollisionsLabel = FindNode("TotalCollisions") as Label;
        collisionDamageLabel = FindNode("CollisionDamage") as Label;
        tube0ProgressBar = FindNode("Tube0ProgressBar") as ProgressBar;
        tube1ProgressBar = FindNode("Tube1ProgressBar") as ProgressBar;
        tube2ProgressBar = FindNode("Tube2ProgressBar") as ProgressBar;
        tube3ProgressBar = FindNode("Tube3ProgressBar") as ProgressBar;

        tube0ProgressBar.Value = 0.1f;
        tube1ProgressBar.Value = 0.3f;
        tube2ProgressBar.Value = 0.5f;
        tube3ProgressBar.Value = 0.8f;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (focusShip == null)
        {
            totalCollisionsLabel.Text = "Collisions: [No ship focus]";
            collisionDamageLabel.Text = "Damage: [No ship focus]";
            tube0ProgressBar.Value = 0;
            tube1ProgressBar.Value = 0;
            tube2ProgressBar.Value = 0;
            tube3ProgressBar.Value = 0;
            return;
        }
        
        totalCollisionsLabel.Text = "Collisions: " + focusShip.TotalCollisionCount;
        collisionDamageLabel.Text = "Damage: " + focusShip.TotalDamage;
        tube0ProgressBar.Value = focusShip.Turret.GetTubeCooldown(0);
        tube1ProgressBar.Value = focusShip.Turret.GetTubeCooldown(1);
        tube2ProgressBar.Value = focusShip.Turret.GetTubeCooldown(2);
        tube3ProgressBar.Value = focusShip.Turret.GetTubeCooldown(3);
    }

    public void SetFocusShip(ColonyShip ship)
    {
        if (ship == null)
        {
            GD.PrintErr("Cannot SetFocusShip(null)");
            return;
        }

        this.focusShip = ship;

        tube0ProgressBar.MaxValue = focusShip.Turret.CooldownDuration;
        tube1ProgressBar.MaxValue = focusShip.Turret.CooldownDuration;
        tube2ProgressBar.MaxValue = focusShip.Turret.CooldownDuration;
        tube3ProgressBar.MaxValue = focusShip.Turret.CooldownDuration;
    }
}
