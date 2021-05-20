using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackout : MonoExtension {
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = TryGetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            return;
        }
        spriteRenderer.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            return;
        }
        spriteRenderer.enabled = true;
    }
}
