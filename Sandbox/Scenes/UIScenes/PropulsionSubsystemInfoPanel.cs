using Godot;
using System;

public class PropulsionSubsystemInfoPanel : Control
{
    //Internal references
    ColonyShip focusShip;

    OptionButton driveSelectOptionButton;

    Label mainThrusterLabel;
    TextureProgress mainThrusterProgressBar;
    Label portForeThrusterLabel;
    TextureProgress portForeThrusterProgressBar;
    Label portAftThrusterLabel;
    TextureProgress portAftThrusterProgressBar;
    Label starboardForeThrusterLabel;
    TextureProgress starboardForeThrusterProgressBar;
    Label starboardAftThrusterLabel;
    TextureProgress starboardAftThrusterProgressBar;
    Label portRetroThrusterLabel;
    TextureProgress portRetroThrusterProgressBar;
    Label starboardRetroThrusterLabel;
    TextureProgress starboardRetroThrusterProgressBar;

    CheckBox automaticControllerCheckBox;
    CheckBox ufoDriveCheckBox;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        automaticControllerCheckBox = FindNode("AutomaticControllerCheckBox") as CheckBox;
        automaticControllerCheckBox.Connect("toggled", this, nameof(HandleAutomaticControllerCheckBoxChanged));
        ufoDriveCheckBox = FindNode("UFODriveCheckBox") as CheckBox;
        ufoDriveCheckBox.Connect("toggled", this, nameof(HandleUFODriveCheckBoxChanged));



        driveSelectOptionButton = FindNode("DriveSelectOptionButton") as OptionButton;
        //driveSelectOptionButton.Connect("item_selected", this, nameof(HandleDriveItemSelected));        

        mainThrusterLabel = FindNode("Main Thruster") as Label;
        portForeThrusterLabel = FindNode("Port Fore Thruster") as Label;
        portAftThrusterLabel = FindNode("Port Aft Thruster") as Label;
        starboardForeThrusterLabel = FindNode("Starboard Fore Thruster") as Label;
        starboardAftThrusterLabel = FindNode("Starboard Aft Thruster") as Label;
        portRetroThrusterLabel = FindNode("Port Retro Thruster") as Label;
        starboardRetroThrusterLabel = FindNode("Starboard Retro Thruster") as Label;

        mainThrusterProgressBar = FindNode("MainThrusterProgressBar") as TextureProgress;
        portForeThrusterProgressBar = FindNode("PortForeThrusterProgressBar") as TextureProgress;
        portAftThrusterProgressBar = FindNode("PortAftThrusterProgressBar") as TextureProgress;
        starboardForeThrusterProgressBar = FindNode("StarboardForeThrusterProgressBar") as TextureProgress;
        starboardAftThrusterProgressBar = FindNode("StarboardAftThrusterProgressBar") as TextureProgress;
        portRetroThrusterProgressBar = FindNode("PortRetroThrusterProgressBar") as TextureProgress;
        starboardRetroThrusterProgressBar = FindNode("StarboardRetroThrusterProgressBar") as TextureProgress;
    }

    public override void _Process(float delta)
    {
        if (focusShip == null)
        {
            return;
        }

        mainThrusterProgressBar.Value = focusShip.ThrusterControls.MainThrottle;
        portForeThrusterProgressBar.Value = focusShip.ThrusterControls.PortForeThrottle;
        portAftThrusterProgressBar.Value = focusShip.ThrusterControls.PortAftThrottle;
        starboardForeThrusterProgressBar.Value = focusShip.ThrusterControls.StarboardForeThrottle;
        starboardAftThrusterProgressBar.Value = focusShip.ThrusterControls.StarboardAftThrottle;
        portRetroThrusterProgressBar.Value = focusShip.ThrusterControls.PortRetroThrottle;
        starboardRetroThrusterProgressBar.Value = focusShip.ThrusterControls.StarboardRetroThrottle;
    }

    public void SetFocusShip(ColonyShip ship)
    {
        //Unsubscribe from old
        if (focusShip != null)
        {
            focusShip.PropulsionController.IsProcessingChanged -= HandlePropulsionControllerProcessingChanged;
            focusShip.ThrusterControls.OnUFODriveEnabledChanged -= HandleUFODriveEnabledChanged;
            //focusShip.OnPropulsionModeChanged -= HandleShipPropulsionModeChanged;
            focusShip = null;
        }

        //Subscribe to new
        focusShip = ship;
        focusShip.PropulsionController.IsProcessingChanged += HandlePropulsionControllerProcessingChanged;
        focusShip.ThrusterControls.OnUFODriveEnabledChanged += HandleUFODriveEnabledChanged;

        HandlePropulsionControllerProcessingChanged(focusShip.PropulsionController, focusShip.PropulsionController.IsProcessing);
        HandleUFODriveCheckBoxChanged(focusShip.ThrusterControls.IsUFODriveEnabled);
        //focusShip.OnPropulsionModeChanged += HandleShipPropulsionModeChanged;
        //HandleShipPropulsionModeChanged(focusShip, focusShip.PropulsionMode);
    }

    void HandleAutomaticControllerCheckBoxChanged(bool pressed)
    {
        SynchronizePropulsionMode();
    }

    void HandleUFODriveCheckBoxChanged(bool pressed)
    {
        SynchronizePropulsionMode();
    }

    void SynchronizePropulsionMode()
    {
        if (focusShip == null)
            return;

        focusShip.PropulsionController.IsProcessing = automaticControllerCheckBox.Pressed;        
        focusShip.ThrusterControls.IsUFODriveEnabled = ufoDriveCheckBox.Pressed;

    }
    /*
    void HandleDriveItemSelected(int index)
    {
        GD.Print("Drive item selected: " + index);
        focusShip.PropulsionMode = (ShipPropulsionMode)index;
    }

    void HandleShipPropulsionModeChanged(ColonyShip ship, ShipPropulsionMode newPropulsionMode)
    {
        GD.Print("ColonyShip propulsion mode changed: " + newPropulsionMode);
        driveSelectOptionButton.Selected = (int)newPropulsionMode;
    }*/

    public void HandlePropulsionControllerProcessingChanged(AbstractSubsystemController controller, bool isEnabled)
    {
        automaticControllerCheckBox.Pressed = isEnabled;

        //If the automatic propulsion controller is enabled, don't allow the user to affect the UFO drive checkbox
        //The pressed state of the checkbox should still be updated correctly, but the user can't touch it
        ufoDriveCheckBox.Disabled = isEnabled;
    }

    public void HandleUFODriveEnabledChanged(bool isEnabled)
    {
        ufoDriveCheckBox.Pressed = isEnabled;
    }
}
