using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackout : MonoExtension {
    private SpriteRenderer[] spriteRenderers;

    private void Start() {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            spriteRenderer.sortingOrder = 11;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            return;
        }
        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            return;
        }
        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            spriteRenderer.enabled = true;
        }
    }
}
