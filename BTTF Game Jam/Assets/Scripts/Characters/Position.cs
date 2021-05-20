using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

    private Transform tf;
    public Vector3 StartPosition { get; private set; }

    private void Start() {
        tf = transform;
        StartPosition = new Vector2(tf.position.x, tf.position.y);
    }

    public void Set(float x, float y, float z = 0) {
        tf.position = new Vector3(x, y, z);
    }

    public Vector3 Get() {
        return tf.position;
    }
}
