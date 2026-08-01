using Godot;
using System;


public partial class CanoSpawner : Node2D
{
    [Export] public PackedScene CanoScene;
    [Export] public float IntervaloSpawn = 1.5f;
    [Export] public float PosX = 320f;      // fora da tela, à direita
    [Export] public float MinY = -100f;     // limite superior do sorteio
    [Export] public float MaxY = 100f;      // limite inferior do sorteio

    private RandomNumberGenerator rng = new RandomNumberGenerator();
    private Timer timer;

    public override void _Ready()
    {
        GD.Print("Spawner pronto");

        rng.Randomize();
        timer = GetNode<Timer>("Timer");
        timer.WaitTime = IntervaloSpawn;
        timer.Timeout += SpawnCano;
        timer.Start();
    }

    private void SpawnCano()
    {
        GD.Print("Timer disparou, tentando spawnar cano...");

        if (CanoScene == null)
        {
            GD.Print("ERRO: CanoScene está vazio! Arraste o cano.tscn no Inspector.");
            return;
        }

        Node2D cano = CanoScene.Instantiate<Node2D>();
        float yAleatorio = rng.RandfRange(MinY, MaxY);

        GD.Print("Spawnando cano em Y = " + yAleatorio);

        cano.Position = new Vector2(PosX, yAleatorio);
        GetParent().AddChild(cano);

        GD.Print("Cano adicionado à cena. Nome: " + cano.Name);
    }
}