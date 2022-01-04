using Godot;
using System;

public class ColonyShip : RigidBody2D, IHasScanSignature, IHasCollisionRadius, IDamageReceiver
{
    float currentHealth;
    float maxHealth = 100f;

    //[Export] string shipName = "HMCS Generic";
    [Export] ShipNames shipName = ShipNames.Unassigned;
    [Export] float maxTorque = 10f;
    [Export] float maxThrust = 10f;
    [Export] float ufoDriveMaxSpeed = 200f;
    [Export] float ufoDriveRotationSpeed = 180f;
    [Export] float safeJumpSpeed = 100f; //Moving faster than this when jumping through a WarpGate will damage the ship
    [Export] float jumpVelocityDamageMultiplier = 1f; //If jumping above the speed limit, multiply speed by this factor to calculate damage

    //Internal
    GameCore gameCore;
    //public SubsystemReferences Subsystems {get; private set;}
    public AbstractSensorsController SensorsController { get; private set; }
    public AbstractNavigationController NavigationController { get; private set; }
    public AbstractPropulsionController PropulsionController { get; private set; }
    public AbstractDefenceController DefenceController { get; private set; }

    ShipStatusInfo shipStatusInfo;
    CollisionShape2D collisionShape;
    public float TotalScanEnergy { get; private set; }
    public int TotalCollisionCount { get; private set; }
    public float TotalDamage { get; private set; }
    public float TotalJumpCost { get; private set; }
    public float TimeElapsed { get; private set; }
    
    public int TorpedoesFired { get; set; }

    bool isLanded = false;
    public event Action<ColonyShip, bool> IsLandedChanged;
    public bool IsLanded { get{return isLanded;} set{if(isLanded != value){isLanded = value; IsLandedChanged?.Invoke(this, isLanded);}} }
    public string MissionResult {get; private set;} = "In progress";

    Thruster portForeThruster;
    Thruster starboardForeThruster;
    Thruster portAftThruster;
    Thruster starboardAftThruster;
    Thruster mainThruster;
    Thruster portRetroThruster;
    Thruster starboardRetroThruster;

    Area2D overlapArea2D;

    Turret turret;
    UFODriveParticles ufoDriveParticles;

    public float UFODriveRotationSpeed { get { return ufoDriveRotationSpeed; } }

    //ShipPropulsionMode propulsionMode;
    //public ShipPropulsionMode PropulsionMode { get { return propulsionMode; } set { if (propulsionMode != value) { propulsionMode = value; OnPropulsionModeChanged?.Invoke(this, propulsionMode); } } }
    //public event Action<ColonyShip, ShipPropulsionMode> OnPropulsionModeChanged;

    //Properties
    public ShipNames ShipName { get { return shipName; } set { shipName = value; } }
    public bool IsAutomaticPropulsionControlEnabled = true;
    public ThrusterControls ThrusterControls { get; private set; }
    public ActiveSensors ActiveSensors { get; private set; }
    public PassiveSensors PassiveSensors { get; private set; }
    public string CurrentSolarSystemName { get; set; }
    public Turret Turret { get { return turret; } }
    public string ScanSignature { get { return "Plasteel:70|Composites:20|Electronics:5|Misc:5"; } }
    public float CollisionRadius { get { return Mathf.Max((collisionShape.Shape as CapsuleShape2D).Height, (collisionShape.Shape as CapsuleShape2D).Radius); } }

    //Events
    public event Action<ColonyShip, string, string> OnShipWarped; //this, departure solar system anme, arrival solar system name
    //public event Action<ColonyShip, string> JumpDriveTriggered; //this, destination solar system name
    //public event Action<ColonyShip, bool> LandingSequenceTriggered; //this, is ship above Kepler438

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gameCore = FindParent("GameCore") as GameCore;
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        portForeThruster = GetNode<Thruster>("PortForeThruster");
        starboardForeThruster = GetNode<Thruster>("StarboardForeThruster");
        portAftThruster = GetNode<Thruster>("PortAftThruster");
        starboardAftThruster = GetNode<Thruster>("StarboardAftThruster");
        mainThruster = GetNode<Thruster>("MainThruster");
        portRetroThruster = GetNode<Thruster>("PortRetroThruster");
        starboardRetroThruster = GetNode<Thruster>("StarboardRetroThruster");
        TorpedoesFired = 0;
        overlapArea2D = GetNode<Area2D>("OverlapArea2D");

        ThrusterControls = new ThrusterControls(mainThruster, portForeThruster, portAftThruster, starboardForeThruster, starboardAftThruster, portRetroThruster, starboardRetroThruster);
        ThrusterControls.OnWarpJumpTriggered += TriggerJumpDrive;
        ThrusterControls.OnLandingSequenceTriggered += TriggerLandingSequence;

        turret = FindNode("Turret") as Turret;
        PassiveSensors = GetNode<PassiveSensors>(nameof(PassiveSensors));
        ActiveSensors = GetNode<ActiveSensors>(nameof(ActiveSensors));
        ActiveSensors.OnScanPerformed += HandleScanPerformed;

        ufoDriveParticles = GetNode<UFODriveParticles>("UFODriveParticles");

        SensorsController = FindNode("SensorsSubsystemController") as AbstractSensorsController;
        NavigationController = FindNode("NavigationSubsystemController") as AbstractNavigationController;
        PropulsionController = FindNode("PropulsionSubsystemController") as AbstractPropulsionController;
        DefenceController = FindNode("DefenceSubsystemController") as AbstractDefenceController;
        SensorsController.parentShip = this;
        NavigationController.parentShip = this;
        PropulsionController.parentShip = this;
        DefenceController.parentShip = this;

        shipStatusInfo = new ShipStatusInfo();

        UpdateShipStatusInfo();
    }

    public override void _Process(float delta)
    {
        Update(); //Causes _Draw to be called again (each frame)
    }

    public override void _PhysicsProcess(float deltaTime)
    {
        UpdateShipStatusInfo();
        //ActiveSensors.GenerateEMSReadings();
        //ActiveSensors.PerformScan(0f, Mathf.Pi * 2f, 400f);
        PassiveSensors.GeneratePassiveSensorReadings();

        if (SensorsController.IsProcessing)
        {
            SensorsController.SensorsUpdate(shipStatusInfo, ActiveSensors, PassiveSensors, deltaTime);
        }

        if (NavigationController.IsProcessing)
        {
            NavigationController.NavigationUpdate(shipStatusInfo, gameCore.GalaxyMap.GalaxyMapData, deltaTime);
        }

        if (PropulsionController.IsProcessing)
        {
            PropulsionController.PropulsionUpdate(shipStatusInfo, ThrusterControls, deltaTime);
        }

        if (DefenceController.IsProcessing)
        {
            DefenceController.DefenceUpdate(shipStatusInfo, Turret.TurretControls, deltaTime);
        }

        if (!IsLanded)
        {
            TimeElapsed += deltaTime;
        }
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        AppliedForce = state.TotalGravity;
        AppliedTorque = 0f;

        if (ThrusterControls.IsUFODriveEnabled)
        {
            var clampedVelocity = ThrusterControls.UFODriveVelocity.Normalized() * Mathf.Min(ThrusterControls.UFODriveVelocity.Length(), ufoDriveMaxSpeed);
            state.LinearVelocity = clampedVelocity;
            //state.LinearVelocity = ThrusterControls.UFODriveVelocity;
            state.AngularVelocity = ThrusterControls.UFODriveAngularVelocity;
        }
        else
        {
            AddForce(mainThruster.GlobalPosition - GlobalPosition, mainThruster.GetResultantThrustVector());
            AddForce(portRetroThruster.GlobalPosition - GlobalPosition, portRetroThruster.GetResultantThrustVector());
            AddForce(starboardRetroThruster.GlobalPosition - GlobalPosition, starboardRetroThruster.GetResultantThrustVector());
            AddForce(portForeThruster.GlobalPosition - GlobalPosition, portForeThruster.GetResultantThrustVector());
            AddForce(portAftThruster.GlobalPosition - GlobalPosition, portAftThruster.GetResultantThrustVector());
            AddForce(starboardForeThruster.GlobalPosition - GlobalPosition, starboardForeThruster.GetResultantThrustVector());
            AddForce(starboardAftThruster.GlobalPosition - GlobalPosition, starboardAftThruster.GetResultantThrustVector());
        }

        //Enable/Disable the UFO Drive visuals depending on chosen PropulsionMode
        //ufoDriveParticles.SetEmitting(PropulsionMode == ShipPropulsionMode.ManualUFODrive);
        ufoDriveParticles.SetEmitting(ThrusterControls.IsUFODriveEnabled);

        if (Input.IsActionJustPressed("MovementStop"))
        {
            state.LinearVelocity = Vector2.Zero;
            state.AngularVelocity = 0f;
        }

        int contactCount = state.GetContactCount();
        if (contactCount > 0)
        {
            //GD.Print("Contact count: " + contactCount);
            for (int i = 0; i < contactCount; i++)
            {
                var vector = state.GetContactColliderVelocityAtPosition(i);
                //GD.Print("Vector: " + vector);
            }
        }

    }

    public override void _Draw()
    {
        //DrawSetTransformMatrix(GetGlobalTransform().Inverse());

        //subsystems.Sensors.DebugDraw();
        //subsystems.Defence.DebugDraw();
        //subsystems.Navigation.DebugDraw();
        //subsystems.Propulsion.DebugDraw();

        //DrawSetTransformMatrix(Transform2D.Identity);
    }

    void UpdateShipStatusInfo()
    {
        shipStatusInfo.currentSystemName = CurrentSolarSystemName;
        shipStatusInfo.positionWithinSystem = GlobalPosition;
        shipStatusInfo.shipCollisionRadius = GetCollisionRadius();
        shipStatusInfo.linearVelocity = LinearVelocity;
        shipStatusInfo.angularVelocity = AngularVelocity;
        shipStatusInfo.forwardVector = GlobalTransform.x;
        shipStatusInfo.rightVector = -GlobalTransform.y;
        shipStatusInfo.torpedoSpeed = turret.TorpedoSpeed;
        shipStatusInfo.hasLanded = IsLanded;
    }

    float GetCollisionRadius()
    {
        var capsule = collisionShape.Shape as CapsuleShape2D;
        return Mathf.Max(capsule.Radius, capsule.Height);
    }

    void TriggerJumpDrive()
    {
        var overlaps = overlapArea2D.GetOverlappingAreas();
        foreach (Area2D area in overlaps)
        {
            if (area is WarpGate)
            {
                WarpGate warpGate = area as WarpGate;
                string departureSolarSystemName = CurrentSolarSystemName;
                bool warpSuccess = warpGate.TryTeleportShip(this, out string arrivalSolarSystemName, out float jumpCost);
                if (warpSuccess)
                {
                    float jumpSpeedOverLimit = Mathf.Max(0, LinearVelocity.Length() - safeJumpSpeed);
                    ReceiveDamage(jumpSpeedOverLimit * jumpVelocityDamageMultiplier);
                    RecordJumpCost(jumpCost);
                    //GD.Print("Jumpcost: " + jumpCost);

                    OnShipWarped?.Invoke(this, departureSolarSystemName, arrivalSolarSystemName);
                }
            }
        }
    }

    void TriggerLandingSequence()
    {
        if (IsLanded)
            return;

        //GD.Print("Landing sequence triggered. Checking overlaps...");
        var overlaps = overlapArea2D.GetOverlappingAreas();
        foreach (var area in overlaps)
        {
            switch (area)
            {
                case LargeBody largeBody:
                    //GD.Print("Overlapping Large Body...");
                    if (largeBody.Name == "Planet Kepler 438")
                    {
                        //GD.Print("Overlapping Kepler 438");
                        MissionResult = "Mission Accomplished!";
                        IsLanded = true;                        
                    } else {
                        MissionResult = "Wrong planet!";
                        IsLanded = true;                        
                    }
                    break;
            }
        }
    }

    public void OnBodyEntered(Node body)
    {
        TotalCollisionCount++;

        switch (body)
        {            
            case ColonyShip ship:
                Node node = ship.GetNodeOrNull("VelocityRecord");
                if (node != null)
                {
                    VelocityRecord record = node as VelocityRecord;
                    float collisionEnergy = (LinearVelocity - record.VelocityLastFrame).Length();
                    //GD.Print("Collided with ship. Energy: " + collisionEnergy);
                    ReceiveDamage(collisionEnergy);
                }

                
                break;
            default:
                //GD.Print("Body entered: " + body.Name);
                break;
        }
    }

    public void ReceiveDamage(float amount)
    {
        TotalDamage += amount;
    }

    void RecordJumpCost(float jumpCost)
    {
        TotalJumpCost += jumpCost;
    }

    void HandleScanPerformed(float scanCost)
    {
        TotalScanEnergy += scanCost;
    }
}
