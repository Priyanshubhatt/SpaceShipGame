using Godot;
using System;

public struct EMSReading
{
    /// <summary>
    /// For keeping track of the same object each scan
    /// </summary>    
    public ulong ContactID {get; private set;}

    /// <summary>
    /// The angle of the reading (relative to global X axis)
    /// </summary>    
    public float Angle { get; private set; }

    /// <summary>
    /// The strength of the reading, proportional to distance via activeSensors.GConstant
    /// </summary>
    public float Amplitude { get; private set; }

    /// <summary>
    /// The velocity of the detected object relative to current solar system coordinate frame
    /// </summary>    
    public Vector2 Velocity { get; private set; }

    /// <summary>
    /// The collision radius of the detected object
    /// </summary>    
    public float Radius { get; private set; }

    /// <summary>
    /// A more detail description of the object's material composition
    /// </summary>    
    public string ScanSignature { get; private set; }

    /// <summary>
    /// For example, a Warp Gate's destination solar system name
    /// </summary>    
    public string SpecialInfo{get; private set;}

    public EMSReading(ulong contactID, float angle, float ampltitude, Vector2 velocity, float radius, string scanSignature, string specialInfo = null)
    {
        ContactID = contactID;
        Angle = angle;
        Amplitude = ampltitude;
        Velocity = velocity;
        Radius = radius;
        ScanSignature = scanSignature;
        SpecialInfo = specialInfo;
    }
}
