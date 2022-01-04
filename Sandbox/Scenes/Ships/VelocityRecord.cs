using Godot;
using System;

public class VelocityRecord : Node
{
    public Vector2 VelocityLastFrame {get; private set;}
    RigidBody2D parentRigidBody;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        parentRigidBody = GetParent<RigidBody2D>();
    }

    public override void _PhysicsProcess(float delta)
    {
        VelocityLastFrame = parentRigidBody.LinearVelocity;
    }
}
