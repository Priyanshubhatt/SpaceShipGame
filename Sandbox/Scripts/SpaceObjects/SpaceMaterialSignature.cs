using Godot;
using System;
using System.Collections.Generic;

public class SpaceMaterialSignature : Node
{    
    [Export] bool unknown;
    [Export] bool common;
    [Export] bool metal;
    [Export] bool water;
    [Export] bool fisable;
    [Export] bool antimatter;
    
    public int MaterialSignature { get; private set; } = 0;

    public override void _Ready()
    {
        if(unknown){
            MaterialSignature += (0x1 << (int)SpaceMaterials.Unknown);
        }

        if(common){
            MaterialSignature += (0x1 << (int)SpaceMaterials.Common);
        }

        if(metal){
            MaterialSignature += (0x1 << (int)SpaceMaterials.Metal);
        }

        if(water){
            MaterialSignature += (0x1 << (int)SpaceMaterials.Water);
        }

        if(fisable){
            MaterialSignature += (0x1 << (int)SpaceMaterials.Fisable);
        }

        if(antimatter){
            MaterialSignature += (0x1 << (int)SpaceMaterials.Antimatter);
        }
    }
}
