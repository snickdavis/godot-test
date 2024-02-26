using Godot;

public partial class slime : Node2D, Slime {
    public void PlayHurtAnimation() {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("hurt");        
        GetNode<AnimationPlayer>("AnimationPlayer").Play("walk");
    }

    public void PlayWalkAnimation() {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("walk");
    }

}

public interface Slime {
    public void PlayWalkAnimation();
    public void PlayHurtAnimation();
}