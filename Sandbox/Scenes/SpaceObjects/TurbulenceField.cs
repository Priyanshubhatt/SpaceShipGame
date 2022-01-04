using Godot;
using System;

public class TurbulenceField : Area2D
{
    [Export] NodePath particleFieldNodePath;

    Particles2D particles;
    ParticlesMaterial particlesMaterial;

    RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
    OpenSimplexNoise noise;
    Vector2 samplePosition = new Vector2();
    Vector2 sampleVelocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        particles = GetNode<Particles2D>("Particles2D");
        particlesMaterial = particles.ProcessMaterial as ParticlesMaterial;

        noise = new OpenSimplexNoise();
        noise.Octaves = 4;
        noise.Period = 20f;
        noise.Persistence = 0.8f;
    }

    public override void _PhysicsProcess(float delta)
    {
        sampleVelocity.x += randomNumberGenerator.RandfRange(-1f, 1f);
        sampleVelocity.y += randomNumberGenerator.RandfRange(-1f, 1f);
        samplePosition += sampleVelocity * delta;
        
        float xNoise = noise.GetNoise2d(samplePosition.x, samplePosition.y);
        float yNoise = noise.GetNoise2d(samplePosition.y, samplePosition.x);

        particlesMaterial.Direction = new Vector3(xNoise, yNoise, 0f);

        GravityVec = new Vector2(xNoise, yNoise);
    }
}
