using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waypoint : MonoExtension {
    [SerializeField]
    private UnityEvent ReachEvent;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            return;
        }
        ReachEvent?.Invoke();
    }
}
