using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position {

    private Transform transform;
    public Vector3 StartPosition { get; private set; }

    public Position(Character parent) {
        transform = parent.transform;
        StartPosition = new Vector2(transform.position.x, transform.position.y);
    }

    public void Set(float x, float y, float z = 0) {
        transform.position = new Vector3(x, y, z);
    }
}
