using Godot;
using System;

public partial class ChaoScroll : Node2D
{
    [Export] public float Speed = 150f;      // combine com a velocidade dos canos
    [Export] public float TileWidth = 288f;  // largura da imagem do chão

    [Export] public Sprite2D Chao1;
    [Export] public Sprite2D Chao2;

    private float distanciaPercorrida = 0f;

    public override void _PhysicsProcess(double delta)
    {
        distanciaPercorrida += Speed * (float)delta;

        Chao1.Position = new Vector2(WrapX(0f), Chao1.Position.Y);
        Chao2.Position = new Vector2(WrapX(TileWidth), Chao2.Position.Y);
    }

    // Calcula a posição X do tile a partir da distância total já percorrida,
    // em vez de "empurrar" a posição anterior. Isso é auto-corretivo: não
    // importa a velocidade, o framerate, ou se um tile passou do outro no
    // mesmo frame — a fórmula sempre devolve a posição correta.
    private float WrapX(float faseInicial)
    {
        float largura2x = TileWidth * 2f;
        return Mathf.PosMod(faseInicial - distanciaPercorrida + TileWidth, largura2x) - TileWidth;
    }
}