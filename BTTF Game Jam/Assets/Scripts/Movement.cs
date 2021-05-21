using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoExtension {
    private Rigidbody2D body;
    private Player player;
    private bool lastDir;

    private void Start() {
        body = TryGetComponent<Rigidbody2D>();
        player = TryGetComponent<Player>();
        lastDir = false;
    }

    public void Update() {
        Vector2 move = new Vector2(0, 0);

        if (player.Locked) {
            body.velocity = move;
            player.Animation.SetAnimation(AnimationState.IDLE);
            return;
        }

        if (Input.GetKey(KeyCode.W)) {
            move.y += 1;
        }

        if (Input.GetKey(KeyCode.S)) {
            move.y += -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            move.x += -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            move.x += 1;
        }

        if (Mathf.Abs(move.x) + Mathf.Abs(move.y) > 0) {
            player.Animation.SetAnimation(AnimationState.WALK);

            if (move.x == 0) {
                if (lastDir) {
                    player.Position.Right();
                } else {
                    player.Position.Left();
                }
            } else if (move.x < 0) {
                player.Position.Left();
                lastDir = false;
            } else {
                player.Position.Right();
                lastDir = true;
            }
        } else {
            player.Animation.SetAnimation(AnimationState.IDLE);
        }

        body.velocity = move.normalized * player.Properties.MovementSpeed;
    }
}
