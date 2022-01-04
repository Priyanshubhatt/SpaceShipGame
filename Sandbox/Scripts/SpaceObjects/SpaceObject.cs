using Godot;
using System;
using System.Collections.Generic;

public class SpaceObject : Node2D
{
    [Export] string description = "An interesting space object...";
    [Export] List<SpaceMaterials> materials;
    [Export] GravitySignature gravitySignature;

    public GravitySignature GravitySignature { get { return gravitySignature; } }
    public int MaterialSignature { get; private set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CalculateMaterialSignature();
    }

    void CalculateMaterialSignature()
    {
        MaterialSignature = 0;
        if(materials.Count > 0){
            foreach(SpaceMaterials material in materials){
                MaterialSignature += (0x1 << (int)material);
            }
        }
    }
}
