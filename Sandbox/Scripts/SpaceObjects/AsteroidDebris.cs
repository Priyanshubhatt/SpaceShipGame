using Godot;
using System;

public class AsteroidDebris : RigidBody2D, IDamageReceiver, IHasScanSignature, IHasCollisionRadius
{
    
    public string ScanSignature { get { return "Rock:90|Common:10"; } }

    public float CollisionRadius { get { return (collisionShape.Shape as CircleShape2D).Radius; } }

    CollisionShape2D collisionShape;

    public override void _Ready()
    {
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");

        Random rand = new Random();
        AngularVelocity = (float)((rand.NextDouble() - 0.5f) * 55);
    }

    public override void _PhysicsProcess(float delta)
    {
        if(GlobalPosition.LengthSquared() > 10000000){
            QueueFree();
        }
    }

    public void ReceiveDamage(float amount)
    {
        QueueFree();
    }
}
