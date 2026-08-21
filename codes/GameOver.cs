
using Godot;
using System;
 
public partial class GameOver : Control
{
	// Arraste o Label "Your Score: ..." aqui pelo Inspector
	[Export] public Label ScoreLabel;
 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
 
	// Chamado pelo CharacterBody2d assim que essa tela é instanciada
	public void MostrarResultado(int pontuacaoFinal)
	{
		if (ScoreLabel != null)
			ScoreLabel.Text = "Your Score:" + pontuacaoFinal;
	}
	 private void _on_play_again_pressed()
	 {
		 GetTree().Paused = false;
		 GetTree().ChangeSceneToFile("res://cenas/node_2d.tscn");
	 }
 
	 private void _on_exit_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://cenas/menu.tscn");
	}
 
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
 