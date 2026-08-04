using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	[Export] public float JumpCooldown = 0.25f;
	public const float Speed = 300.0f;
	public const float JumpVelocity = -300.0f;

	// Limites verticais da tela (viewport é 288x512)
	[Export] public float TopLimit = 0f;
	[Export] public float BottomLimit = 500f;

	private bool Isjumping = false;
	private bool Canjump = true;
	private bool isDead = false;

	private AnimatedSprite2D playerSprite;

	public override void _Ready()
	{
		playerSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (isDead)
			return;

		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity += GetGravity() * (float)delta;

		if (Input.IsActionJustPressed("jump") && Canjump == true)
		{
			Canjump = false;
			Isjumping = true;
			playerSprite.Play("new_animation");
			velocity.Y = JumpVelocity;

			// Duração para o proximo pulo
			GetTree().CreateTimer(0.3).Timeout += () =>
			{
				Isjumping = false;
			};
			// Cooldown para o proximo pulo
			GetTree().CreateTimer(JumpCooldown).Timeout += () =>
			{
				Canjump = true;
			};
		}

		Velocity = velocity;
		MoveAndSlide();

		// Impede o personagem de sair da tela por cima
		if (Position.Y < TopLimit)
		{
			Position = new Vector2(Position.X, TopLimit);
			Velocity = new Vector2(Velocity.X, 0);
		}

		// Encostou perto do chão/fora da tela por baixo = game over
		if (Position.Y > BottomLimit)
		{
			GameOver();
		}
	}

	private void _on_area_entered(Area2D area)
	{
		GameOver();
	}

	private void _on_body_entered(Node2D body)
	{
		GameOver();
	}

	private void GameOver()
	{
		if (isDead)
			return;

		isDead = true;
		GD.Print("Game Over!");
		playerSprite.Play("hit");
		GetTree().Paused = true;
	}
}