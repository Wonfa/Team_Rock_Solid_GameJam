using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoExtension {

    private static Lock<GameObject> ICON = new Lock<GameObject>();

    [SerializeField]
    private float interactDistance = 2.5f;
    [SerializeField]
    private Vector2 offset = new Vector2(0, 2);
    
    [SerializeField]
    private UnityEvent interactEvent;

    private Position position;
    private GameObject icon;

    private void Awake() {
        if (ICON == null) {
            return;
        }
        ICON.Value = TryLoad<GameObject>("InteractIcon");
    }

    private void Start() {
        position = TryGetComponent<Position>();
        icon = TryCreate(ICON.Value);
        icon.transform.parent = transform;
        icon.transform.position = position.Get() + offset;
    }

    private void Update() {
        if (Vector2.Distance(position.Get(), Game.Player.Position.Get()) >= interactDistance) {
            return;
        }
    }
}
