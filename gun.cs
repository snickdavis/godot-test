using System.Linq;
using Godot;
using Godot.Collections;

public partial class gun : Area2D {
    public override void _PhysicsProcess(double delta) {
        Array<Node2D> enemiesInRange = GetOverlappingBodies();
        if (enemiesInRange.Count > 0) {
            Node2D target = enemiesInRange.First();
            LookAt(target.GlobalPosition);
        }
    }

    public void Shoot() {
        PackedScene bullet = GD.Load<PackedScene>("res://bullet.tscn");
        Node2D new_bullet = (Node2D)bullet.Instantiate();
        new_bullet.GlobalPosition = GetNode<Marker2D>("%shooting_point").GlobalPosition;
        new_bullet.GlobalRotation = GetNode<Marker2D>("%shooting_point").GlobalRotation;
        GetNode<Marker2D>("%shooting_point").AddChild(new_bullet);
    }

    private void _OnTimerTimeout() {
        Shoot();
    }
}
