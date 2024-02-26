using Godot;

public partial class mob : CharacterBody2D, IEnemy {
    CharacterBody2D player;
    int health = 5;

    public override void _Ready() {
        GetNode<Slime>("%Slime").PlayWalkAnimation();
        player = (CharacterBody2D)GetNode("/root/survivors_game/player_character");
    }

    public override void _PhysicsProcess(double delta) {
        Vector2 direction = GlobalPosition.DirectionTo(player.GlobalPosition);
        Velocity = direction * 300;
        MoveAndSlide();
    }

    public void TakeDamage() {        
        health -= 1;
        GetNode<Slime>("%Slime").PlayHurtAnimation();

        if (health == 0) {
            QueueFree();
            Node2D smoke = (Node2D)GD.Load<PackedScene>("res://smoke_explosion/smoke_explosion.tscn").Instantiate();
            GetParent().AddChild(smoke);
            smoke.GlobalPosition = GlobalPosition;
        }
    }

}

internal interface IEnemy {
    public void TakeDamage();
}