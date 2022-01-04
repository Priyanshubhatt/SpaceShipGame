using Godot;
using System;

public class ShipSelectPanel : PanelContainer
{
    GameCore gameCore;
    OptionButton optionButton;

    public event Action<ShipNames> OnShipSelectionChanged;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        optionButton = FindNode("OptionButton") as OptionButton;

        gameCore = FindParent("GameCore") as GameCore;
        gameCore.OnColonyShipSpawned += HandleColonyShipSpawned;

        foreach (var pair in gameCore.ColonyShips)
        {
            optionButton.AddItem(pair.Value.ShipName.ToString());
        }
    }

    public void SetFocusShip(ColonyShip ship)
    {
        for (int i = 0; i < optionButton.GetItemCount(); i++)
        {
            if (optionButton.GetItemText(i).CompareTo(ship.ShipName.ToString()) == 0)
            {
                optionButton.Select(i);
            }
        }
    }
    void HandleColonyShipSpawned(ColonyShip newColonyShip)
    {
        optionButton.AddItem(newColonyShip.ShipName.ToString());
    }

    public void HandleOptionButtonItemSelected(int id)
    {        
        OnShipSelectionChanged?.Invoke((ShipNames)Enum.Parse(typeof(ShipNames), optionButton.GetItemText(id)));
    }
}
