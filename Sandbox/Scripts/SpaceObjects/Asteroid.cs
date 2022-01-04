using Godot;
using System;

public class Asteroid : RigidBody2D, IHasScanSignature, IHasCollisionRadius, IDamageReceiver
{
    [Export] float angularVelocityRange = 5;
    [Export] PackedScene asteroidDebrisScene;

    CollisionShape2D collisionShape;
    //SpaceMaterialSignature scanSignature;
    public float CollisionRadius { get { return (collisionShape.Shape as CircleShape2D).Radius; } }

    public string ScanSignature { get { return "Rock:90|Common:10"; } }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        //scanSignature = GetNode<SpaceMaterialSignature>("SpaceMaterialSignature");

        Random rand = new Random();
        AngularVelocity = (float)((rand.NextDouble() - 0.5f) * angularVelocityRange);


    }

    public override void _PhysicsProcess(float delta)
    {
        if(GlobalPosition.LengthSquared() > 10000000){
            QueueFree();
        }
    }

    public void ReceiveDamage(float amount)
    {
        Shatter();
        //CallDeferred("Shatter");
    }

    void Shatter()
    {
        int debrisCount = RandomNumberUtility.RandomInt(1, 5);

        for (int i = 0; i < debrisCount; i++)
        {
            //TODO: Spawn a bunch of fast-moving debris
            Vector2 offset = Vector2.Right * CollisionRadius * 0.75f;
            float angleStep = Mathf.Pi * 2f / debrisCount;
            offset = offset.Rotated( angleStep * i);

            float outboundSpeed = RandomNumberUtility.RandomFloat(100f, 600f);

            float outboundAngularVelocity = RandomNumberUtility.RandomFloat(-300f, 300f);

            RigidBody2D debrisInstance = asteroidDebrisScene.Instance() as RigidBody2D;
            debrisInstance.GlobalPosition = GlobalPosition + offset;
            debrisInstance.LinearVelocity = offset.Normalized() * outboundSpeed;
            debrisInstance.AngularVelocity = outboundAngularVelocity;
            
            //GetParent().AddChild(debrisInstance);
            GetParent().CallDeferred("add_child", debrisInstance);
        }


        QueueFree();
    }
}
