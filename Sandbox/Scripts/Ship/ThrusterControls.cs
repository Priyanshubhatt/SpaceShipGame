using System;
using Godot;
public class ThrusterControls
{
    //Properties
    public float MainThrottle { get { return mainThruster.Throttle; } set { mainThruster.Throttle = value; } }
    public float PortRetroThrottle { get { return portRetroThruster.Throttle; } set { portRetroThruster.Throttle = value; } }
    public float StarboardRetroThrottle { get { return starboardRetroThruster.Throttle; } set { starboardRetroThruster.Throttle = value; } }
    public float PortForeThrottle { get { return portForeThruster.Throttle; } set { portForeThruster.Throttle = value; } }
    public float PortAftThrottle { get { return portAftThruster.Throttle; } set { portAftThruster.Throttle = value; } }
    public float StarboardForeThrottle { get { return starboardForeThruster.Throttle; } set { starboardForeThruster.Throttle = value; } }
    public float StarboardAftThrottle { get { return starboardAftThruster.Throttle; } set { starboardAftThruster.Throttle = value; } }

    bool isUFODriveEnabled = false;
    public event Action<bool> OnUFODriveEnabledChanged;
    public bool IsUFODriveEnabled {get{return isUFODriveEnabled;} set{if(isUFODriveEnabled != value){isUFODriveEnabled = value; OnUFODriveEnabledChanged?.Invoke(isUFODriveEnabled);}}}

    public Vector2 UFODriveVelocity; //Can be used for early iterations, just to get the ship moving
    public float UFODriveAngularVelocity;

    public event Action OnWarpJumpTriggered;
    public event Action OnLandingSequenceTriggered;
    

    //Internal
    Thruster mainThruster;
    Thruster portForeThruster;
    Thruster portAftThruster;
    Thruster starboardForeThruster;
    Thruster starboardAftThruster;
    Thruster portRetroThruster;
    Thruster starboardRetroThruster;

    public ThrusterControls(Thruster mainThruster, Thruster portForeThruster, Thruster portAftThruster, Thruster starboardForeThruster, Thruster starboardAftThruster, Thruster portRetroThruster, Thruster starboardRetroThruster)
    {
        this.mainThruster = mainThruster;
        this.portForeThruster = portForeThruster;
        this.portAftThruster = portAftThruster;
        this.starboardForeThruster = starboardForeThruster;
        this.starboardAftThruster = starboardAftThruster;
        this.portRetroThruster = portRetroThruster;
        this.starboardRetroThruster = starboardRetroThruster;
    }

    /// <summary>
    /// Call this method in order to attempt to use a WarpGate.false Ship must be overlapping with a gate when triggered.
    /// </summary>
    public void TriggerWarpJump()
    {
        OnWarpJumpTriggered?.Invoke();
    }

    public void TriggerLandingSequence()
    {
        OnLandingSequenceTriggered?.Invoke();
    }
}