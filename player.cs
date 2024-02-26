using System.Linq;
using Godot;
using Godot.Collections;

public partial class player : CharacterBody2D {
    public const double DAMAGE_RATE = 5.0;

    public static HappyBoo happyBoo;
    public double health = 100.0;

    [Signal]
    public delegate void HealthDepletedEventHandler();

    public override void _Ready() {
        happyBoo = GetNode<HappyBoo>("HappyBoo");
    }

    public override void _PhysicsProcess(double delta) {
        var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Velocity = direction * 500;
        MoveAndSlide();

        if (Velocity.Length() > 0.0) {
            happyBoo.PlayWalkAnimation();
        } else {
            happyBoo.PlayIdleAnimation();
        }

        Array<Node2D> overlappingMobs = GetNode<Area2D>("%hitbox").GetOverlappingBodies();
        health -= DAMAGE_RATE * overlappingMobs.Count() * delta;

        GetNode<ProgressBar>("%player_character_health").Value = health;

        if (health <= 0.0) {
            EmitSignal(SignalName.HealthDepleted);
            GD.Print("DEAD");
        }
    }
}
