using Godot;

public partial class mob : CharacterBody2D {
    public static Slime slime;
    CharacterBody2D player;

    public override void _Ready() {
        slime = GetNode<Slime>("Slime");
        player = (CharacterBody2D)GetNode("/root/survivors_game/player_character");
    }

    public override void _PhysicsProcess(double delta) {
        Vector2 direction = GlobalPosition.DirectionTo(player.GlobalPosition);
        Velocity = direction * 600;
        MoveAndSlide();
    }
}
