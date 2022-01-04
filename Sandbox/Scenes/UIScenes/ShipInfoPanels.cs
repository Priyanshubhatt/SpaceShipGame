using Godot;
using System;

public class ShipInfoPanels : VBoxContainer
{
    //Internal
    GameCore gameCore;
    ShipSelectPanel shipSelectPanel;
    SensorsSubsystemInformationPanel sensorsSubsystemInformationPanel;
    PropulsionSubsystemInfoPanel propulsionSubsystemInformationPanel;
    DefenceSubsystemInformationPanel defenceSubsystemInformationPanel;
    ColonyShip focusShip;
    public ColonyShip FocusShip { get { return focusShip; } set { if (focusShip != value) { var oldValue = focusShip; focusShip = value; FocusShipChanged?.Invoke(oldValue, focusShip); } } }
    public event Action<ColonyShip, ColonyShip> FocusShipChanged; //Old focus, new focus

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gameCore = FindParent("GameCore") as GameCore;

        shipSelectPanel = FindNode("ShipSelectPanel") as ShipSelectPanel;
        shipSelectPanel.OnShipSelectionChanged += HandleShipSelectionChanged;

        sensorsSubsystemInformationPanel = FindNode("SensorsSubsystemInformationPanel") as SensorsSubsystemInformationPanel;
        propulsionSubsystemInformationPanel = FindNode("PropulsionSubsystemInformationPanel") as PropulsionSubsystemInfoPanel;
        defenceSubsystemInformationPanel = FindNode("DefenceSubsystemInformationPanel") as DefenceSubsystemInformationPanel;

        FocusShipChanged += HandleFocusShipChanged;
    }

    public override void _Process(float delta)
    {
        if (FocusShip != null && !FocusShip.PropulsionController.IsProcessing)
        {
            //The automatic propulsion code is disable. Allow manual control of propulsion.
            if (FocusShip.ThrusterControls.IsUFODriveEnabled)
            {
                ComputeUFOThrusterInputs(delta);
            }
            else
            {
                ComputeManualThrusterInputs(delta);
            }
        }
    }

    void HandleShipSelectionChanged(ShipNames newShipName)
    {
        if (gameCore.ColonyShips.TryGetValue(newShipName, out ColonyShip chosenShip))
        {
            FocusShip = chosenShip;
        }
    }

    void HandleFocusShipChanged(ColonyShip oldFocusShip, ColonyShip newFocusShip)
    {
        //Unsubscribe
        if (oldFocusShip != null)
        {
            oldFocusShip.OnShipWarped -= HandleFocusShipWarped;            
        }

        MainCamera mainCamera = gameCore.MainCamera;
        mainCamera.GetParent().RemoveChild(mainCamera);
        mainCamera.SetFocus(newFocusShip);

        //var startingViewportContainer = gameCore.SolarSystemViewportContainersByName[gameCore.GalaxyMap.StartingNode.Name];
        var targetViewportContainer = newFocusShip.FindParent("*ViewportContainer*");
        targetViewportContainer.GetChild(0).AddChild(mainCamera);

        sensorsSubsystemInformationPanel.SetFocusShip(focusShip);
        propulsionSubsystemInformationPanel.SetFocusShip(focusShip);
        defenceSubsystemInformationPanel.SetFocusShip(focusShip);
        shipSelectPanel.SetFocusShip(focusShip);

        //Update viewport containers
        var currentViewportContainer = gameCore.SolarSystemViewportContainersByName[focusShip.CurrentSolarSystemName];
        gameCore.MoveChild(currentViewportContainer, gameCore.GetChildCount() - 1);

        //Subscribe
        focusShip.OnShipWarped += HandleFocusShipWarped;        

        // Shows/Hides mission accomplished screen 
        if (newFocusShip != null)
        {
            gameCore.MissionAccomplishedUI.SetFocusShip(focusShip);

            gameCore.MissionAccomplishedUI.Visible = newFocusShip.IsLanded;
        }
    }

    private void HandleFocusShipWarped(ColonyShip ship, string oldSolarSystem, string newSolarSystem)
    {
        gameCore.MainCamera.GetParent()?.RemoveChild(gameCore.MainCamera);
        var destinationViewportContainer = gameCore.SolarSystemViewportContainersByName[newSolarSystem];
        destinationViewportContainer.GetChild(0).AddChild(gameCore.MainCamera);

        gameCore.MoveChild(destinationViewportContainer, gameCore.GetChildCount() - 1);
    }

    void ComputeManualThrusterInputs(float delta)
    {
        if (focusShip == null)
            return;

        var ThrusterControls = focusShip.ThrusterControls;

        ThrusterControls.MainThrottle = 0f;
        ThrusterControls.PortForeThrottle = 0f;
        ThrusterControls.PortAftThrottle = 0f;
        ThrusterControls.StarboardForeThrottle = 0f;
        ThrusterControls.StarboardAftThrottle = 0f;
        ThrusterControls.PortRetroThrottle = 0f;
        ThrusterControls.StarboardRetroThrottle = 0f;

        if (Input.IsActionPressed("MovementForward"))
        {
            ThrusterControls.MainThrottle += 1f;
        }

        if (Input.IsActionPressed("MovementBackward"))
        {
            ThrusterControls.PortRetroThrottle += 1f;
            ThrusterControls.StarboardRetroThrottle += 1f;
        }

        if (Input.IsActionPressed("MovementPort"))
        {
            ThrusterControls.StarboardForeThrottle += 1;
            ThrusterControls.StarboardAftThrottle += 1;
        }

        if (Input.IsActionPressed("MovementStarboard"))
        {
            ThrusterControls.PortForeThrottle += 1;
            ThrusterControls.PortAftThrottle += 1;
        }

        if (Input.IsActionPressed("MovementCounterclockwise"))
        {
            ThrusterControls.PortAftThrottle += 1;
            ThrusterControls.StarboardForeThrottle += 1;
        }

        if (Input.IsActionPressed("MovementClockwise"))
        {
            ThrusterControls.PortForeThrottle += 1;
            ThrusterControls.StarboardAftThrottle += 1;
        }

        if (Input.IsActionJustPressed("FireTorpedo"))
        {
            focusShip.Turret.TurretControls.TriggerTube(0, 0);
        }

        if (Input.IsActionJustPressed("TriggerJumpDrive"))
        {
            ThrusterControls.TriggerWarpJump();
        }

        if (Input.IsActionJustPressed("TriggerLandingSequence"))
        {
            ThrusterControls.TriggerLandingSequence();
        }
    }

    void ComputeUFOThrusterInputs(float delta)
    {
        if (focusShip == null)
            return;

        var ThrusterControls = focusShip.ThrusterControls;

        ThrusterControls.UFODriveVelocity = Vector2.Zero;
        ThrusterControls.UFODriveAngularVelocity = 0f;

        if (Input.IsActionPressed("MovementForward"))
        {
            ThrusterControls.UFODriveVelocity += Vector2.Up;
        }

        if (Input.IsActionPressed("MovementBackward"))
        {
            ThrusterControls.UFODriveVelocity += Vector2.Down;
        }

        if (Input.IsActionPressed("MovementPort"))
        {
            ThrusterControls.UFODriveVelocity += Vector2.Left;
        }

        if (Input.IsActionPressed("MovementStarboard"))
        {
            ThrusterControls.UFODriveVelocity += Vector2.Right;
        }

        if (Input.IsActionPressed("MovementClockwise"))
        {
            ThrusterControls.UFODriveAngularVelocity += focusShip.UFODriveRotationSpeed * delta;
        }

        if (Input.IsActionPressed("MovementCounterclockwise"))
        {
            ThrusterControls.UFODriveAngularVelocity -= focusShip.UFODriveRotationSpeed * delta;
        }

        ThrusterControls.UFODriveVelocity = ThrusterControls.UFODriveVelocity.Normalized();

        if (Input.IsActionJustPressed("FireTorpedo"))
        {
            focusShip.Turret.TurretControls.TriggerTube(0, 0);
        }
    }
}
