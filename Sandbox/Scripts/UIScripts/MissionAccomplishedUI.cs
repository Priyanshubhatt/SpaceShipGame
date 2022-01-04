using Godot;
using System;

public class MissionAccomplishedUI : Control
{
    Label missionAccomplishedLabel;
    Label shipName;
    Label timeTakenData;
    Label damageTakenData;
    Label collisionsNumber;
    Label torpedoesFired;
    Label scanEnergyUsed;
    Label jumpCost;
    /*
    Label asteroidsDestroyed;
    Label warpgateDamage;
    Label fuelUsed;
    Label activeScansNumber;
    Label warpgateJumps;*/
    ShipInfoPanels shipInfoPanels;
    ColonyShip focusShip;

    public void SetFocusShip(ColonyShip ship)
    {
        this.focusShip = ship;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        missionAccomplishedLabel = FindNode("MissionAccomplished") as Label;
        shipName = FindNode("ShipName") as Label;
        timeTakenData = FindNode("TimeTakenData") as Label;
        damageTakenData = FindNode("DamageTakenData") as Label;
        collisionsNumber = FindNode("CollisionsNumber") as Label;
        torpedoesFired = FindNode("TorpedoesFired") as Label;
        scanEnergyUsed = FindNode("ScanEnergyUsed") as Label;
        jumpCost = FindNode("JumpCost") as Label;

        shipInfoPanels = GetParent().FindNode("ShipInfoPanels") as ShipInfoPanels;
        shipInfoPanels.FocusShipChanged += HandleFocusShipChanged;
        HandleFocusShipChanged(null, shipInfoPanels.FocusShip);

        var gameCore = FindParent("GameCore") as GameCore;
        if (focusShip == null)
        {
            missionAccomplishedLabel.Text = "---";
            shipName.Text = "---";
            timeTakenData.Text = "---";
            damageTakenData.Text = "---";
            collisionsNumber.Text = "---";
            torpedoesFired.Text = "---";
            scanEnergyUsed.Text = "---";
            jumpCost.Text = "---";
            return;
        }


    }

    private void HandleFocusShipChanged(ColonyShip oldFocus, ColonyShip newFocus)
    {
        //Unsubscibe
        if (oldFocus != null)
        {
            oldFocus.IsLandedChanged -= HandleFocusShipIsLandedChanged;
        }

        //Subscribe
        if (newFocus != null)
        {
            newFocus.IsLandedChanged += HandleFocusShipIsLandedChanged;
            RefreshText(newFocus);
        }
    }

    void HandleFocusShipIsLandedChanged(ColonyShip focusShip, bool hasLanded)
    {
        if (hasLanded)
        {
            RefreshText(focusShip);
            Visible = true;
        }
        else
        {
            Visible = false;
        }
    }

    void RefreshText(ColonyShip focusShip)
    {
        missionAccomplishedLabel.Text = focusShip.MissionResult;
        shipName.Text = focusShip.Name;
        timeTakenData.Text = focusShip.TimeElapsed.ToString("0.000");
        damageTakenData.Text = focusShip.TotalDamage.ToString();
        collisionsNumber.Text = focusShip.TotalCollisionCount.ToString();
        torpedoesFired.Text = focusShip.TorpedoesFired.ToString();
        scanEnergyUsed.Text = focusShip.TotalScanEnergy.ToString();
        jumpCost.Text = focusShip.TotalJumpCost.ToString();
    }
}
