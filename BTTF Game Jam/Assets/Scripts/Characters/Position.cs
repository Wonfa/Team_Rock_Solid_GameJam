using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

    private Transform tf;
    public Vector3 StartPosition { get; private set; }

    private void Awake() {
        tf = transform;
        StartPosition = new Vector3(tf.position.x, tf.position.y, tf.position.z);
    }

    public void Set(float x, float y, float z = 0) {
        tf.position = new Vector3(x, y, z);
    }

    public void Set(Vector3 position) {
        Set(position.x, position.y, position.z);
    }

    public Vector3 Get() {
        return tf.position;
    }

    public void Left() {
        tf.localScale = new Vector3(Mathf.Abs(tf.localScale.x), tf.localScale.y, tf.localScale.z);
    }

    public void Right() {
        tf.localScale = new Vector3(-Mathf.Abs(tf.localScale.x), tf.localScale.y, tf.localScale.z);
    }
}
