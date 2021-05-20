using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoExtension {
    public Position Position { get; private set; }

    protected void Start() {
        Position = TryGetComponent<Position>();
    }
}
