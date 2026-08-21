using Godot;
using System;

public partial class Menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<AnimatedSprite2D>(".").Play("default");

	} 

	private void _on_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://cenas/node_2d.tscn");
	}

	private void _on_score_pressed()
	{
		
	}

	private void _on_exit_pressed()
	{
		GetTree().Quit();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
