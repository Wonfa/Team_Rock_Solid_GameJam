using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody2D body;
    private Player player;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    public void Update() {
        Vector2 move = new Vector2(0, 0);

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

        body.velocity = move.normalized * player.Properties.MovementSpeed;
    }
}
