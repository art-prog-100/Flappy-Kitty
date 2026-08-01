using Godot;
using System;

public partial class Cano : Node2D
{
    [Export] public float Speed = 150f;

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(-Speed * (float)delta, 0);

        // Se saiu totalmente da tela pela esquerda, se destrói
        if (Position.X < -100)
        {
            QueueFree();
        }
    }
}
