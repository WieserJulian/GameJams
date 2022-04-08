using Godot;
using System;

public class HitBox : Area2D
{
    private GameManager _Manager = null;
    public override void _Ready()
    {
        _Manager = GetNode<GameManager>("/root/GameManager");
        Connect("body_entered",this,"onBodyEntered");
    }

    private void onBodyEntered(object body){
        if (typeof(Player).IsInstanceOfType(body)){
            _Manager.Trys += 1;
            GetTree().ChangeSceneTo(_Manager.CurrenScene);
        }
    }
}
