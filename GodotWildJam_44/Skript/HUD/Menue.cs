using Godot;
using System;

public class Menue : Control
{
    private Label leastDeaths = null;
    private GameManager _Manager = null;
    private int leastDeath = 0;
    public override void _Ready()
    {
        _Manager = GetNode<GameManager>("/root/GameManager");
        _Manager.Connect("changeLeastTrys", this, "changeTrys");
        
        leastDeaths = 
            GetNode<Label>("MarginContainer/CenterContainer/VBoxContainer/CenterContainer/VBoxContainer/LeastTrys");
        if (_Manager.LeastTrys == Int32.MaxValue)
        {
            leastDeaths.Text = "Least Death per Run: None";
        }
        else
        {
            leastDeaths.Text = "Least Death per Run: " + _Manager.LeastTrys;
        }
        leastDeath = _Manager.LeastTrys;
    }

    private void _on_Start_pressed()
    {
        _Manager.Level = 1;
        GetTree().ChangeSceneTo(_Manager.CurrenScene);
    }

    private void _on_Exit_pressed()
    {
        GetTree().Quit(1);
    }

    private void changeTrys(int value)
    {
        leastDeath = value;
        leastDeaths.Text = "Least Death per Run: " + leastDeath;
    }
}
