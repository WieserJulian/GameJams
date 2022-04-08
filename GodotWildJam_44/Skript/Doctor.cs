using Godot;
using System;

public class Doctor : Node2D
{
    private GameManager _Manager = null;
    private bool active = true;
    public override void _Ready()
    {
        _Manager = GetNode<GameManager>("/root/GameManager");
    }

    private void _on_StaticBody2D_body_entered(object body)
    {
        if (typeof(Player).IsInstanceOfType(body))
        {
            active = false;
            _Manager.Level += 1;
            GetTree().ChangeSceneTo(_Manager.CurrenScene); 
        }
    }
}
