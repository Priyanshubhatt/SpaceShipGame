using Godot;
using System;

public class LargeBody : Area2D, IHasScanSignature
{
    [Export] GravitySignature gravitySignature;
    [Export] string scanSignature = "RareGases:80|Neutronium:5|Unknown:15";

    //Properties
    public GravitySignature GravitySignature { get { return gravitySignature; } private set { gravitySignature = value; } }
    public string ScanSignature { get { return scanSignature; } }

}
