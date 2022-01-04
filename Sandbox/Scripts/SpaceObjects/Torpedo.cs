using Godot;
using System;

public class Torpedo : Area2D, IHasScanSignature, IHasCollisionRadius
{
    [Export] float maxAge = 10f;
    [Export] PackedScene explosionScene;

    public static float ExplosionRadius { get; private set; } = 150f;
    public static float LaunchSpeed {get; private set;} = 600;

    //Internal
    float age = 0f;
    CollisionShape2D collisionShape2D;
    Area2D explosionArea;
    bool hasExploded = false;

    //Properties
    public string ScanSignature { get { return "Metals:25|Antimatter:75"; } }
    public float CollisionRadius { get { return Mathf.Max((collisionShape2D.Shape as CapsuleShape2D).Radius, (collisionShape2D.Shape as CapsuleShape2D).Height); } }
    public Vector2 LinearVelocity { get; set; }
    public ColonyShip OwnedByShip { get; set; }
    public float FuseDuration { get; set; }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        collisionShape2D = FindNode("CollisionShape2D") as CollisionShape2D;
        explosionArea = FindNode("ExplosionArea") as Area2D;
        ((FindNode("ExplosionCollisionShape2D") as CollisionShape2D).Shape as CircleShape2D).Radius = ExplosionRadius;
    }

    public override void _PhysicsProcess(float delta)
    {
        GlobalPosition = GlobalPosition + LinearVelocity * delta;

        age += delta;

        //Fade away after aging out
        if (age >= maxAge)
        {
            QueueFree();
        }

        //Explode after fuse expires
        if (FuseDuration > 0 && age >= FuseDuration)
        {
            Explode();
        }
    }

    public void OnBodyEntered(Node node)
    {
        switch (node)
        {
            case ColonyShip ship:
                {
                    if (ship == OwnedByShip)
                        return;

                    //TODO: Do we want ships to be able to shoot other ships?
                }
                break;
            case RigidBody2D body2D:
                {
                    Explode();
                }
                break;

            default:
                GD.PrintErr("Unexpected torpedo collision with: " + node.Name);
                break;
        }
    }

    void Explode()
    {
        //Only explode once
        if (hasExploded)
            return;

        hasExploded = true;

        //Damage everything within our explosion radius
        var bodies = explosionArea.GetOverlappingBodies();
        foreach (var body in bodies)
        {
            if (body is IDamageReceiver explosionReceiver)
            {
                explosionReceiver.ReceiveDamage(100f);
            }
        }

        Node2D explosion = explosionScene.Instance() as Node2D;
        explosion.GlobalPosition = GlobalPosition;
        explosion.GlobalScale = Vector2.One * Torpedo.ExplosionRadius;
        GetParent().AddChild(explosion);

        QueueFree();
    }
}
