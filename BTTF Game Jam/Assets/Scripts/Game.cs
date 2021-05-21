using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Player Player { get; private set; }
    public static Game Instance { get; private set; }

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Instance = this;
    }

    [SerializeField]
    private GameObject endScreenMenuFailed;
    [SerializeField]
    private GameObject endScreenMenuSuccess;

    public static void DeathEnding() {
        Player.Locked = true;
        Instance.endScreenMenuFailed.SetActive(true);
    }
    public static void CompletedEnding() {
        Player.Locked = true;
        Instance.endScreenMenuSuccess.SetActive(true);
    }
}
