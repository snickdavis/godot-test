using Godot;

public partial class SurvivorsGame : Node2D {

    public void SpawnMob(string spawnName) {
        Node2D newMob = (Node2D)GD.Load<PackedScene>(spawnName).Instantiate();
        GetNode<PathFollow2D>("%spawn_path_follow").ProgressRatio = new RandomNumberGenerator().Randf();

        newMob.GlobalPosition = GetNode<PathFollow2D>("%spawn_path_follow").GlobalPosition;
        AddChild(newMob);
    }

    private void _OnTimerTimeout() {
        SpawnMob("res://characters/slime/mob.tscn");
        SpawnMob("res://pine_tree.tscn");
        SpawnMob("res://pine_tree.tscn");
        SpawnMob("res://pine_tree.tscn");
    }

    private void _OnHealthDepeted() {
        GetNode<CanvasLayer>("%game_over").Visible = true;
        GetTree().Paused = true;
    }
}
