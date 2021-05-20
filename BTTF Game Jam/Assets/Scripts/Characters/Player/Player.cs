using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    [SerializeField]
    private PlayerProperties properties;
    public PlayerProperties Properties { get => properties; private set { } }

    public bool Locked { get; set; }

    private new void Start() {
        base.Start();
        Properties.Init();
    }

    public void PickupBattery(Interactable battery) {
        Properties.Batteries.Value--;
    }

    [SerializeField]
    private GameObject redLights;
    [SerializeField]
    private GameObject blueLights;

    public void TimeTravelStageOne(Position pad) {
        if (Properties.BatteriesPlaced.Value > 0) {
            SendMessage("Looks like this device needs power.");
            return;
        }

        if (Properties.Explosion) {
            SendMessage("");
            return;
        }

        Locked = true;
        Position.Set(pad.Get() + new Vector3(0, 0.25f, 0));
        //play time travel animation
        SendMessage("It appears to be working!");
        SendMessage("I might actually travel forward in time!");
        Dialogue.Instance.OnComplete = () => {
            redLights.SetActive(true);
            blueLights.SetActive(false);
            SendMessage("Wait a minute...");
            SendMessage("Why has it gone red!?");
            SendMessage("* Explosion *");
            SendMessage("What happened? It was going so well..");
            SendMessage("Alright, lets head back to the garage and see if we can fix it.");
            Dialogue.Instance.OnComplete = () => { Game.Player.Locked = false; return true; };
            return false;
        };
    }

    public new void SendMessage(string message) {
        Debug.Log(message);
        Dialogue.Instance.DisplayText = message;
    }
}
