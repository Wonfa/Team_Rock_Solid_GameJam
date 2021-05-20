using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : Character
{
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
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Game.Player.Position.Get();

        if ((Vector2.Distance(Position.Get(), playerPos) < chaseRadius) && (Vector2.Distance(Position.StartPosition, Position.Get()) <= 10.0f))
        {
            Debug.Log("Chasing");
            Chase();
        }
        else
        {
            Debug.Log("Patrolling");
            Patrol();
        }
    }

    void Patrol()
    {
        Position.Set(Vector2.MoveTowards(transform.position, moveSpot.position, patrolSpeed * Time.deltaTime));

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    void Chase()
    {
        Position.Set(Vector2.MoveTowards(Position.Get(), playerPos, chaseSpeed * Time.deltaTime));
    }
}
