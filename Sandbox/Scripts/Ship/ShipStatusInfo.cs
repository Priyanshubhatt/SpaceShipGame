using Godot;
using System;

/// <summary>
/// Provides information about the ship's current position, velocity, etc.
/// </summary>
public class ShipStatusInfo
{
    /// <summary>
    /// The name of the solar system the ship is currently travelling within
    /// </summary>
    public string currentSystemName;

    /// <summary>
    /// The ship's position relative to the center of the current solar system
    /// </summary>
    public Vector2 positionWithinSystem = new Vector2();

    /// <summary>
    /// How radius of the ship as approximated by a circle
    /// </summary>
    public float shipCollisionRadius;

    /// <summary>
    /// What direction and how fast the ship is travelling within the current solar system
    /// </summary>
    public Vector2 linearVelocity;

    /// <summary>
    /// How quickly the ship is rotating
    /// </summary>
    public float angularVelocity;

    /// <summary>
    /// A vector (in solar system coordinate space) pointing forward along the ship's bow
    /// </summary>
    public Vector2 forwardVector;

    /// <summary>
    /// A vector (in solar system coordinate space) pointing directly starboard
    /// </summary>
    public Vector2 rightVector;    
    
    /// <summary>
    /// How fast torpedoes will travel when launched
    /// </summary>
    public float torpedoSpeed;

    /// <summary>
    /// A flag indicated whether the ship has successfully landed
    /// </summary>
    public bool hasLanded;

    public event Action<string, string> OnWarpJumpCompelted; //Old solar system name, new/current solar system name

    void HandleWarpJumpCompleted(string oldSystemName, string newSystemName){
        //Just echo the event. Hides any reference to the ColonyShip from student subsystem controllers
        OnWarpJumpCompelted?.Invoke(oldSystemName, newSystemName);
    }
}
