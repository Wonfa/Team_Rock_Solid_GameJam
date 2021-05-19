using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public PlayerProperties Properties { get; private set; }
    private new void Start() {
        base.Start();
        Properties = new PlayerProperties();
    }
}
