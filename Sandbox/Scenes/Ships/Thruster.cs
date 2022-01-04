using Godot;
using System;

public class Thruster : Node2D
{
    [Export] float maxThrustForce;

    //Properties
    public float Throttle { get { return throttle; } set { throttle = Mathf.Clamp(value, 0f, 1f); flameSprite.Scale = Vector2.One * throttle; } }

    //Internal
    float throttle;
    Sprite flameSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        flameSprite = GetNode<Sprite>("Flame");
    }

    public Vector2 GetResultantThrustVector()
    {
        return Vector2.Right.Rotated(GlobalRotation) * Throttle * maxThrustForce;
    }
}
