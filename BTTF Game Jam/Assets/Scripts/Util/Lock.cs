using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock<T> {
    private T value;
    private bool locked;

    public T Value {
        get => value;
        set {
            if (locked) {
                return;
            }
            locked = true;
            this.value = value;
        }
    }

    public Lock() {
        locked = false;
    }
}
