using Godot;
using System;

public class MainCamera : Camera2D
{
    Node2D cameraTargetNode;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
        if (cameraTargetNode != null)
        {
            Vector2 targetPosition = cameraTargetNode.GlobalPosition;
            GlobalPosition = targetPosition;
        }

        if (Input.IsActionJustReleased("ZoomOut") && Zoom.Length() > 0.25f)
        {
            Zoom = Zoom * 0.9f;
        }

        if(Input.IsActionJustReleased("ZoomIn") && Zoom.Length() < 4f){
            Zoom = Zoom * 1.1f;
        }
    }

    public void SetFocus(Node2D focus)
    {
        cameraTargetNode = focus;
        //GD.Print("Camera focus set to: " + focus);
    }
}
