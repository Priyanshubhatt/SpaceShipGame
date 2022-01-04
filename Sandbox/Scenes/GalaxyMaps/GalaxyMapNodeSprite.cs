using Godot;
using System;

[Tool]
public class GalaxyMapNodeSprite : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var parent = GetParent();

        if (parent == null)
            return;

        Texture texture = null;
        switch (parent.Name)
        {
            case SolarSystemNames.AlphaCentauri:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/CreamVioletPlanet.png") as Texture;
                break;
            case SolarSystemNames.Aquarii:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/Planet103.png") as Texture;
                break;
            case SolarSystemNames.BarnardsStar:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/Sun.png") as Texture;
                break;
            case SolarSystemNames.Cygni:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/Planet104.png") as Texture;
                break;
            case SolarSystemNames.Groombridge:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/OrangePlanet.png") as Texture;
                break;
            case SolarSystemNames.Indi:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/IcePlanet.png") as Texture;
                break;
            case SolarSystemNames.Kepler438:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/FrostPlanet.png") as Texture;
                break;
            case SolarSystemNames.Kruger:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/StormPlanet.png") as Texture;
                break;
            case SolarSystemNames.Luyten:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/CyanPlanet.png") as Texture;
                break;
            case SolarSystemNames.Quaid:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/RedLinesPlanet.png") as Texture;
                break;
            case SolarSystemNames.Sirius:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/PurplePlanet.png") as Texture;
                break;
            case SolarSystemNames.Sol:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/EarthLikePlanet.png") as Texture;
                break;
            case SolarSystemNames.Wolf359:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/CyanPlanet1.png") as Texture;
                break;
            case SolarSystemNames.Yennefer:
                texture = GD.Load("res://Sandbox/Sprites/SpaceObjects/Planet082.png") as Texture;
                break;

            default:
                GD.PrintErr("Unrecognized parent name");
                break;
        }

        if (texture != null)
        {
            //GD.Print("Updating GalaxyMapNode sprite for parent: " + parent.Name);
            this.Texture = texture;
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
