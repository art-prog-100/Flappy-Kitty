
using Godot;
 
public partial class ChaoScroll : Node2D
{
    [Export] public float Speed = 150f;      // combine com a velocidade dos canos
    [Export] public float TileWidth = 288f;  // largura da imagem do chão
 
    [Export] public Sprite2D Chao1;
    [Export] public Sprite2D Chao2;
 
    public override void _PhysicsProcess(double delta)
    {
        Vector2 move = new Vector2(-Speed * (float)delta, 0);
 
        Chao1.Position += move;
        Chao2.Position += move;
 
        // Quando uma cópia sai totalmente da tela pela esquerda,
        // reposiciona ela logo depois da outra, à direita
        if (Chao1.Position.X <= -TileWidth)
            Chao1.Position = new Vector2(Chao2.Position.X + TileWidth, Chao1.Position.Y);
 
        if (Chao2.Position.X <= -TileWidth)
            Chao2.Position = new Vector2(Chao1.Position.X + TileWidth, Chao2.Position.Y);
    }
}
 