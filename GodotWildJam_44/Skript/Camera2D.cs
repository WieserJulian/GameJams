using Godot;
using System;

public class Camera2D : Godot.Camera2D
{
    private Position2D _topLeft = null;
    private Position2D _bottomRight = null;

    public override void _Ready()
    {
        _topLeft = GetNode<Position2D>("Limits/TopLeft");
        _bottomRight = GetNode<Position2D>("Limits/BottomRigth");
        LimitTop = (int) _topLeft.Position.y;
        LimitLeft = (int) _topLeft.Position.x;
        LimitBottom = (int) _bottomRight.Position.y;
        LimitRight = (int) _bottomRight.Position.x;
    }
}