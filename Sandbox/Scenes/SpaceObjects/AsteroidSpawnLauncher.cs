using Godot;
using System;
using System.Collections.Generic;

public class AsteroidSpawnLauncher : Node2D
{
    [Export] int maxSpawnCount = 6;
    [Export] float spawnPeriod = 3f;
    [Export] float launchSpeedMin = 100f;
    [Export] float launchSpeedMax = 300f;

    PackedScene asteroidPackedScene;
    RandomNumberGenerator randomizer = new RandomNumberGenerator();
    List<Asteroid> spawn = new List<Asteroid>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        asteroidPackedScene = GD.Load<PackedScene>("res://Sandbox/Scenes/SpaceObjects/Asteroid.tscn");

        randomizer.Randomize();

        CallDeferred(nameof(Tick));
    }

    public void OnTimerTimeout()
    {
        CallDeferred(nameof(Tick));
    }

    void Tick()
    {
        CleanList();
        if (spawn.Count < maxSpawnCount)
        {
            SpawnAsteroid();
        }
    }

    void CleanList()
    {
        for (int i = spawn.Count - 1; i >= 0; i--)
        {
            if (spawn[i] == null)
            {
                spawn.RemoveAt(i);
            }
        }
    }

    void SpawnAsteroid()
    {
        var newAsteroid = asteroidPackedScene.Instance() as Asteroid;

        newAsteroid.GlobalPosition = GlobalPosition;
        
        float randomSpeed = randomizer.RandfRange(launchSpeedMin, launchSpeedMax);
        newAsteroid.LinearVelocity = Vector2.Right.Rotated(GlobalRotation) * randomSpeed;

        GetParent().AddChild(newAsteroid);
        spawn.Add(newAsteroid);
    }
}
