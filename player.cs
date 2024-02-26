using Godot;

public partial class player : CharacterBody2D {
    public static HappyBoo happyBoo;

    public override void _Ready() {
        base._Ready();
        happyBoo = GetNode<HappyBoo>("HappyBoo");
    }

    public override void _PhysicsProcess(double delta) {
        //base._PhysicsProcess(delta);

        var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Velocity = direction * 1000;
        MoveAndSlide();

        if (Velocity.Length() > 0.0) {
            happyBoo.PlayWalkAnimation();
        } else {
            happyBoo.PlayIdleAnimation();
        }
    }
}
