using Godot;
using System;
using System.Collections.Generic;

public class GameCore : Node
{
    //Exports
    [Export] SimulationMode simulationMode = SimulationMode.Alpha;
    //[Export] string startFocusedOnShipName = "Nostromo";
    [Export] ShipNames startFocusedOnShip = ShipNames.Nostromo;
    [Export] ulong galaxySeed = 0;

    //Internal
    ShipInfoPanels shipInfoPanels;
    Control helpUI;
    CanvasLayer hudRoot;
    MainCamera mainCamera;
    readonly List<PackedScene> colonyShipScenes = new List<PackedScene>();
    MissionAccomplishedUI missionAccomplishedUI;
    public MissionAccomplishedUI MissionAccomplishedUI {get{return missionAccomplishedUI;}}
        
    public MainCamera MainCamera { get { return mainCamera; } }
    public GalaxyMap GalaxyMap { get; private set; }
    public float TotalElapsedTime { get; private set; }
    public Dictionary<string, ViewportContainer> SolarSystemViewportContainersByName { get; private set; } = new Dictionary<string, ViewportContainer>();
    public SimulationMode SimulationMode { get { return simulationMode; } }
    public static float EMSInterferenceScale { get; private set; }
    public Dictionary<ShipNames, ColonyShip> ColonyShips = new Dictionary<ShipNames, ColonyShip>();

    
    public event Action<ColonyShip> OnColonyShipSpawned; //ship name, colonyShip reference

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        foreach (ShipNames shipName in Enum.GetValues(typeof(ShipNames)))
        {
            if(shipName == ShipNames.Unassigned)
                continue;
            
            colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/" + shipName.ToString() + "ColonyShip.tscn"));

            Type defenceControllerType = Type.GetType(shipName + "DefenceController");
            var defenceController = Activator.CreateInstance(defenceControllerType);

        }
/*
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/BismarkColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/EnterpriseColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/EventHorizonColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/FlyingDutchmanColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/GalacticaColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/MilanoColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/NormandyColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/NostromoColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/PillarOfAutumnColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/PlanetExpressColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/RamaColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/RedDwarfColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/SerenityColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/SSAnneColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/Thunderbird3ColonyShip.tscn"));
        colonyShipScenes.Add(GD.Load<PackedScene>("res://Sandbox/Scenes/Ships/YamatoColonyShip.tscn"));
*/
        SetupNodeReferences();

        PackedScene chosenGalaxyMapScene = null;
        switch (simulationMode)
        {
            case SimulationMode.Alpha:
                chosenGalaxyMapScene = GD.Load<PackedScene>("res://Sandbox/Scenes/GalaxyMaps/GalaxyMapAlpha.tscn");
                break;
            case SimulationMode.Beta:
                chosenGalaxyMapScene = GD.Load<PackedScene>("res://Sandbox/Scenes/GalaxyMaps/GalaxyMapBeta.tscn");
                break;
            case SimulationMode.Gamma:
                chosenGalaxyMapScene = GD.Load<PackedScene>("res://Sandbox/Scenes/GalaxyMaps/GalaxyMapGamma.tscn");
                break;
        }
        LoadGalaxy(chosenGalaxyMapScene);
    }

    void SetupNodeReferences()
    {
        shipInfoPanels = FindNode("ShipInfoPanels") as ShipInfoPanels;
        hudRoot = GetNode<CanvasLayer>("HUD");
        helpUI = FindNode("HelpUI") as Control;
        mainCamera = GetNode<MainCamera>("MainCamera");
        missionAccomplishedUI = FindNode("MissionAccomplishedUI") as MissionAccomplishedUI;
    }

    /// <summary>
    /// Called every frame update
    /// </summary>
    /// /// <param name="delta">The time elapsed since the last _Process update</param>
    public override void _Process(float delta)
    {
        TotalElapsedTime += delta;
        
        if (Input.IsActionJustPressed("ToggleHelpView"))
        {
            helpUI.Visible = !helpUI.Visible;
        }

        if (Input.IsActionJustPressed("ToggleGalaxyMapView"))
        {
            if (GalaxyMap != null)
            {
                GalaxyMap.Visible = !GalaxyMap.Visible;
            }
        }

        if (Input.IsActionJustPressed("ui_cancel"))
        {
            GetTree().Quit();
        }

        if (Input.IsActionJustPressed("PauseGame"))
        {
            GetTree().Paused = !GetTree().Paused;
        }
    }

    void LoadGalaxy(PackedScene galaxyScene)
    {
        GalaxyMap = galaxyScene.Instance() as GalaxyMap;
        hudRoot.AddChild(GalaxyMap);
        GalaxyMap.Visible = false;

        //Randomize galaxy map edge weights?
        if(simulationMode == SimulationMode.Gamma && galaxySeed != 0){
            GalaxyMap.RandomizeEdgeWeights(galaxySeed);
        }
        
        foreach (GalaxyMapNode mapNode in GalaxyMap.Nodes)
        {
            var newSolarSystem = LoadSolarSystemIntoViewportContainer(mapNode.Name);
        }

        var startingViewportContainer = SolarSystemViewportContainersByName[GalaxyMap.StartingNode.Name];
        MoveChild(startingViewportContainer, GetChildCount() - 1);

        //Spawn colony ships
        ColonyShip firstColonyShip = null;

        for (int i = 0; i < colonyShipScenes.Count; i++)
        {
            var newColonyShip = colonyShipScenes[i].Instance() as ColonyShip;
            //newColonyShip.LandingSequenceTriggered += HandleColonyShipLandingSequenceTriggered;
            ColonyShips.Add(newColonyShip.ShipName, newColonyShip);

            //Move colony ship back to origin
            if (newColonyShip != null)
            {
                if (newColonyShip.GetParent() != null)
                    newColonyShip.GetParent().RemoveChild(newColonyShip);

                SolarSystemViewportContainersByName[GalaxyMap.StartingNode.Name].GetChild(0).AddChild(newColonyShip);
                //gameObjectsRoot.AddChild(newColonyShip);
                newColonyShip.CurrentSolarSystemName = GalaxyMap.StartingNode.Name;
                newColonyShip.GlobalPosition = Vector2.Left * 100f + Vector2.Up * 100f * i;
            }

            OnColonyShipSpawned?.Invoke(newColonyShip);

            if (firstColonyShip == null)
                firstColonyShip = newColonyShip;
        }

        //Set camera/info panel focus      
        ColonyShip focusShip = null;
        foreach (var pair in ColonyShips)
        {
            if (pair.Key == startFocusedOnShip)
            {
                focusShip = pair.Value;
            }
        }

        if (focusShip == null)
        {
            GD.PrintErr("No focus ship designed in GameCore inspector panel. Choosing Nostromo by default.");
            focusShip = ColonyShips[ShipNames.Nostromo];
        }
        else
        {
            shipInfoPanels.FocusShip = focusShip;
        }
    }

    Viewport LoadSolarSystemIntoViewportContainer(string solarSystemName)
    {
        var newViewportContainer = new ViewportContainer
        {
            AnchorBottom = 1f,
            AnchorTop = 0f,
            AnchorLeft = 0f,
            AnchorRight = 1f,
            MarginBottom = 0f,
            MarginTop = 0f,
            MarginLeft = 0f,
            MarginRight = 0f,
            Name = solarSystemName + "ViewportContainer",
        };
        AddChild(newViewportContainer);

        var newViewport = new Viewport
        {
            Size = GetTree().Root.Size,
            Name = solarSystemName + "Viewport",
        };
        newViewportContainer.AddChild(newViewport);

        //Load new solar system scene
        PackedScene solarSystemScene = GD.Load<PackedScene>("res://Sandbox/Scenes/SolarSystems/" + solarSystemName + ".tscn");
        var newSolarSystem = solarSystemScene.Instance();
        newViewport.AddChild(newSolarSystem);

        //Find all the warp gates in the new solar system and disable any that aren't relevant to the current galaxy map
        var warpGatesParent = newSolarSystem.GetNode("WarpGates");
        foreach (Node2D child in warpGatesParent.GetChildren())
        {
            if (child != null && child is WarpGate)
            {
                bool isOnMap = false;
                WarpGate gate = (WarpGate)child;
                foreach (Node mapNode in GalaxyMap.Nodes)
                {
                    if (gate.Name.Contains(mapNode.Name))
                    {
                        isOnMap = true;
                        break;
                    }
                }

                //Delete it if it leads to a solar system that's not part of this galaxy
                if (!isOnMap)
                {
                    child.QueueFree();
                }
            }
        }

        SolarSystemViewportContainersByName.Add(solarSystemName, newViewportContainer);
        return newViewport;
    }
}
