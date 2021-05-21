using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Player Player { get; private set; }

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public static void DeathEnding() {
        Player.Locked = true;
        Player.SendMessage("Death Ending");
    }
    public static void CompletedEnding() {
        Player.Locked = true;
        Player.SendMessage("Completed Ending");
    }
}
