using Godot;
using System;

public class GameManager : Node
{
    [Signal]
    public delegate void changeTrys(int value);
    [Signal]
    public delegate void changeLeastTrys(int value);
    

    [Signal]
    public delegate void changeLevel(int value);
    
    public Timer timer = new Timer();
    
    const int LevelSize = 1;
    
    public PackedScene CurrenScene = null;
    private PackedScene[] Levels = new PackedScene[LevelSize+1];
    private PackedScene FinishLevel = ResourceLoader.Load<PackedScene>("res://Scene/Finish.tscn");
    private PackedScene StartLevel = ResourceLoader.Load<PackedScene>("res://Scene/Start.tscn");
    private int trys = 0;
    private int level = 0;
    private int leastTrys= Int32.MaxValue;
    public override void _Ready()
    {
        Levels[0] = StartLevel;
        
        for (int i = 1; i <= LevelSize; i++)
        {
            Levels[i] = ResourceLoader.Load<PackedScene>("res://Scene/Level/Level_" + i + ".tscn");
        }
    }
    
    public int Trys {
        get { return trys;}
        set {
            trys = value;
            EmitSignal("changeTrys", trys);
        }
    }
    public int Level {
        get { return level;}
        set {
            level = value;
            if (level == LevelSize+1)
            {
                CurrenScene = FinishLevel;
                EmitSignal("changeLevel", level);
            }else
            {
                CurrenScene = Levels[level];
                EmitSignal("changeLevel", level);
            }
        }
    }

    public int LeastTrys
    
    {
        get { return leastTrys; }
        set
        {
            leastTrys = value;
            EmitSignal("changeLeastTrys", leastTrys);
        }
    }
}
