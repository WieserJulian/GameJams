using Godot;
using System;

public class Ladder : Node2D
{
    
    private TileMap ladder = null;
    private TileMap ladderPlattform = null;
    public override void _Ready()
    {
        ladder = GetNode<TileMap>("Ladder");
        ladderPlattform = GetNode<TileMap>("LadderPlattform");
        foreach (Vector2 cell in ladder.GetUsedCells())
        {
            
        }
    }
    
    
    
}
