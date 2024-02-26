using Godot;
using System;

public partial class happy_boo : Node2D, HappyBoo {
    public void PlayIdleAnimation() {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("idle");
    }

    public void PlayWalkAnimation() {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("walk");
    }
}

public interface HappyBoo {
    public void PlayIdleAnimation();
    public void PlayWalkAnimation();
}