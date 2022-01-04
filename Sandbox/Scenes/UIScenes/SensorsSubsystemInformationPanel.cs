using Godot;
using System;

public class SensorsSubsystemInformationPanel : Control
{
    ColonyShip focusShip;
    Label infoText;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        infoText = FindNode("InfoText") as Label;
    }

    public override void _Process(float delta)
    {
        if(focusShip == null){

            infoText.Text = "No Ship Selected";
            return;
        }
        
        //int nearbyReadingsCount = focusShip.ActiveSensors.EMSReadings.Count;

        infoText.Text = 
        "Total Jump Cost: " + focusShip.TotalJumpCost 
        + "\n Time: " + focusShip.TimeElapsed.ToString("0.000")
        + "\n Scan Energy: " + focusShip.TotalScanEnergy.ToString("0.00");
    }

    public void SetFocusShip(ColonyShip ship){
        this.focusShip = ship;
    }
}
