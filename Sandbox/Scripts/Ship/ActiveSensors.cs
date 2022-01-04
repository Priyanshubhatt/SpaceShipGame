using Godot;
using System;
using System.Collections.Generic;

public class ActiveSensors : Area2D, IActiveSensors
{
    GameCore gameCore;
    GalaxyMap galaxyMap;


    public const float EMConstant = 1f;
    //public const float EMSRange = 30f;
    //public LayerMask EMSMask;

    RandomNumberGenerator random = new RandomNumberGenerator();

    //public List<EMSReading> EMSReadings { get; private set; } = new List<EMSReading>();
    //public float EMSInterferenceScale { get; private set; } = 0f;
    public float GConstant { get; private set; } = 3f;

    public event Action<float> OnScanPerformed; //Energy cost

    public List<EMSReading> PerformScan(float heading, float arc, float range)
    {
        float scanArea = Mathf.Pi * Mathf.Pow(range, 2) * arc / (Mathf.Pi * 2);

        List<EMSReading> readings = new List<EMSReading>();

        var bodies = GetOverlappingBodies();
        var areas = GetOverlappingAreas();
        
        List<Node2D> nodes = new List<Node2D>();
        foreach(Node2D body in bodies)
            nodes.Add(body);
        foreach(Node2D area in areas)
            nodes.Add(area);

        foreach (Node2D node2D in nodes)
        {
            //Does the current body fall within the scan region?
            Vector2 toNode = node2D.GlobalPosition - GlobalPosition;

            if (toNode.Length() > range)
            {
                //Outside of range
                continue;
            }

            float angleA = Vector2.Right.Rotated(heading).Angle() % (Mathf.Pi * 2f);
            float angleB = toNode.Angle() % (Mathf.Pi * 2f);
            float angleBetween = angleA - angleB;

            if (Mathf.Abs(angleBetween) > arc * 0.5f)
            {
                //Outside of heading/arc
                continue;
            }

            //If so, package it up as an EMSReading to return to the caller
            ulong instanceID = node2D.GetInstanceId();
            Vector2 positionDiff = node2D.GlobalPosition - GlobalPosition;
            float amplitude = GlobalPosition.DistanceTo(node2D.GlobalPosition) / GConstant;
            float angle = Vector2.Right.AngleTo(positionDiff);
            string materialSignature = string.Empty;
            Vector2 velocity = Vector2.Zero;
            float collisionRadius = -1f;
            string specialInfo = null;

            if (node2D is IHasScanSignature signature)
            {
                materialSignature = signature.ScanSignature;
            }

            if (node2D is RigidBody2D rigidBody)
            {
                velocity = rigidBody.LinearVelocity;
            }

            if (node2D is IHasCollisionRadius hasRadius)
            {
                collisionRadius = hasRadius.CollisionRadius;
            }

            if (node2D is WarpGate warpGate)
            {
                specialInfo = warpGate.DestinationSolarSystemName;
            }

            var newReading = new EMSReading(instanceID, angle, amplitude, velocity, collisionRadius, materialSignature, specialInfo);
            readings.Add(newReading);

        }

        OnScanPerformed?.Invoke(scanArea * 0.001f);

        return readings;
    }

    public override void _Process(float delta)
    {
        Update();
    }
    public override void _Draw()
    {
        // DrawSetTransformMatrix(GetGlobalTransform().Inverse());

        // foreach (var reading in EMSReadings)
        // {
        //     DrawLine(GlobalPosition, GlobalPosition + (Vector2.Right * 1f / reading.Amplitude).Rotated(reading.Angle), Colors.Pink);
        // }

        // DrawSetTransformMatrix(Transform2D.Identity);

    }
}
