using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoExtension {

    private static Lock<GameObject> ICON = new Lock<GameObject>();

    [SerializeField]
    private float interactDistance = 1f;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 0.5f, 0);
    
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
        bool check = Vector3.Distance(position.Get(), Game.Player.Position.Get()) <= interactDistance;

        icon.SetActive(check);

        if (check && Input.GetKeyDown(KeyCode.E)) {
            interactEvent?.Invoke();
        }
    }
}
