using System;
using Godot;

public partial class bullet : Area2D {
    public const Double SPEED = 1000.0;
    public const Double RANGE = 1200.0;

    float travelled_distance = 0;
    
    public override void _PhysicsProcess(double delta) {
        Vector2 direction = Vector2.Right.Rotated(Rotation);
        Position += direction * (float)(SPEED * delta);

        travelled_distance += (float)(SPEED * delta);
        if (travelled_distance > RANGE) {
            QueueFree();
        }
    }

    private void _OnBodyEntered(Node2D body) {
        QueueFree();
        
        if (body is IEnemy) {
            ((IEnemy)body).TakeDamage();
        }
    }
}
