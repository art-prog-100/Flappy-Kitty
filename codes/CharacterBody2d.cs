using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	[Export] public float JumpCooldown = 0.25f; 
	public const float Speed = 300.0f;
	public const float JumpVelocity = -300.0f;

	private bool Isjumping = false;
	private bool Canjump = true;

	private AnimatedSprite2D playerSprite;

	public override void _PhysicsProcess(double delta)
	{
		playerSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity += GetGravity() * (float)delta;

		if (Input.IsActionJustPressed("jump")  && Canjump == true)
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
			//Cooldown para o proximo pulo
			GetTree().CreateTimer(JumpCooldown).Timeout += () => 
       		{
            Canjump = true;
        	};
		}
		



		Velocity = velocity;
		MoveAndSlide();
	}
}
