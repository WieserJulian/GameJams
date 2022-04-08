using Godot;
using System;

public class Finish : Node2D
{
    private GameManager _Manager = null;
    private Timer timer = null;
    private Label time = null;
    public override void _Ready()
    {
        _Manager = GetNode<GameManager>("/root/GameManager");
        if (_Manager.Trys < _Manager.LeastTrys){
            _Manager.LeastTrys = _Manager.Trys;
        }

        timer = GetNode<Timer>("Timer");
        time = GetNode<Label>("time");
    }

    public override void _Process(float delta)
    {
        time.Text =  timer.TimeLeft.ToString("0.00") + " s";

    }

    private void _on_Timer_timeout()
    {
        _Manager.Trys = 0;
        _Manager.Level = 0;
        GetTree().ChangeSceneTo(_Manager.CurrenScene);
    }
}
