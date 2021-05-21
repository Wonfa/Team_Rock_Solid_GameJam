using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : Character {
    public float patrolSpeed;
    public float startWaitTime;
    public float chaseRadius;
    public float chaseSpeed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform moveSpot;

    private float waitTime;

    private Vector2 playerPos;
    public Vector2 playerStartPos;

    private new void Start() {
        base.Start();
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update() {
        playerPos = Game.Player.Position.Get();

        if ((Vector2.Distance(Position.Get(), playerPos) < chaseRadius) && (Vector2.Distance(Position.StartPosition, Position.Get()) <= 10.0f)) {
            Chase();
        } else {
            Patrol();
        }

        if (Vector2.Distance(Position.Get(), playerPos) <= 1.0f) {
            Player player = Game.Player;
            player.Position.Set(playerStartPos.x, playerStartPos.y);
            player.Locked = true;
            if (player.Properties.Lives.Value < 3) {
                player.SendMessage("Not again!");
                player.SendMessage("I should be careful, I don't think I can survive much more of that!");
            } else {
                player.SendMessage("What happened? I thought I died...");
            }
            Dialogue.Instance.OnComplete = () => {
                player.Locked = false;
                return true;
            };
            player.Properties.Lives.Value--;
        }
    }

    private void Patrol() {
        Vector2 movePos = Vector2.MoveTowards(transform.position, moveSpot.position, patrolSpeed * Time.deltaTime);
        Position.Set(movePos);
        Face(moveSpot.position.x);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f) {
            if (waitTime <= 0) {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void Chase() {
        Position.Set(Vector2.MoveTowards(Position.Get(), playerPos, chaseSpeed * Time.deltaTime));
        Face(playerPos.x);
    }

    private void Face(float x) {
        if (Position.Get().x < x) {
            Position.Right();
        } else {
            Position.Left();
        }
    }
}
