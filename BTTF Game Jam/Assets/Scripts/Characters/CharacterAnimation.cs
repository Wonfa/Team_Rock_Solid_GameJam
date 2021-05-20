using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoExtension {

    private new Animator animation;

    private void Start() {
        animation = TryGetComponent<Animator>();
    }

    public void SetAnimation(AnimationState state) {
        animation.SetInteger("State", (int)state);
    }
}
