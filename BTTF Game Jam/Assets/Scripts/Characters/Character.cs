using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public Position Position { get; private set; }

    protected void Start() {
        Position = new Position(this);
    }
}
