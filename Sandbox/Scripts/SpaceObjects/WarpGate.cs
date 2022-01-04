using Godot;
using System;

public class WarpGate : Area2D
{
    [Export] string destinationSolarSystemName;

    //Properties
    public string DestinationSolarSystemName { get { return destinationSolarSystemName; } }

    //Internal
    GameCore gameCore;
    string currentSolarSystemName;

    public override void _Ready()
    {
        gameCore = FindParent("GameCore") as GameCore;
        currentSolarSystemName = GetParent().GetParent().Name;
    }

    public bool TryTeleportShip(ColonyShip ship, out string newSolarSystemName, out float jumpCost)
    {
        if (destinationSolarSystemName == null)
        {
            newSolarSystemName = currentSolarSystemName;
            jumpCost = 0f;
            return false;
        }

        float edgeCost = -1f;
        foreach (var edgeData in gameCore.GalaxyMap.GalaxyMapData.edgeData)
        {
            if (edgeData.nodeA.systemName == currentSolarSystemName)
            {
                if (edgeData.nodeB.systemName == destinationSolarSystemName)
                {
                    edgeCost = edgeData.edgeCost;
                    break;
                }
            }
            else if (edgeData.nodeB.systemName == currentSolarSystemName)
            {
                if (edgeData.nodeA.systemName == destinationSolarSystemName)
                {
                    edgeCost = edgeData.edgeCost;
                    break;
                }
            }
        }
        if(edgeCost == -1f){
            newSolarSystemName = currentSolarSystemName;
            jumpCost = 0f;
            return false;
        }

        //Record the ship's position offset relative to this outbound gate
        Vector2 positionOffset = ship.GlobalPosition - this.GlobalPosition;

        //Add ship to new solar system
        ship.GetParent()?.RemoveChild(ship);
        var destinationSolarSystem = gameCore.SolarSystemViewportContainersByName[destinationSolarSystemName].GetChild(0).GetChild(0);
        destinationSolarSystem.AddChild(ship);



        //Find the incoming warpgate and position the ship relative to it
        Node targetNode = destinationSolarSystem.FindNode("WarpGate to " + currentSolarSystemName, true);
        WarpGate incomingWarpGate = targetNode as WarpGate;
        ship.GlobalPosition = incomingWarpGate.GlobalPosition + positionOffset;
        ship.CurrentSolarSystemName = incomingWarpGate.currentSolarSystemName;

        newSolarSystemName = incomingWarpGate.currentSolarSystemName;
        jumpCost = edgeCost;


        return true;
    }
}
