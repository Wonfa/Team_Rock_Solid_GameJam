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
        if (Properties.Explosion) {
            Properties.BatteriesDino.Value--;
        } else {
            Properties.Batteries.Value--;
        }
    }

    [SerializeField]
    private GameObject garage;
    [SerializeField]
    private GameObject dinoLand;
    [SerializeField]
    private GameObject redLights;
    [SerializeField]
    private GameObject blueLights;

    public void TimeTravelStageOne(Position pad) {
        if (Properties.BatteriesPlaced.Value > 0 || Properties.Explosion) {
            SendMessage("Looks like this device needs power.");
            return;
        }

        Locked = true;
        Position.Set(pad.Get() + new Vector3(0, 0.25f, 0));
        //play time travel animation
        SendMessage("It appears to be working!");
        SendMessage("I might finally be able to travel through time.");
        SendMessage("Years of research might finally pay off.");
        Dialogue.Instance.OnComplete = () => {
            redLights.SetActive(true);
            blueLights.SetActive(false);
            dinoLand.SetActive(true);
            garage.SetActive(false);
            SendMessage("Wait a minute...");
            SendMessage("Why has it gone red!?");
            SendMessage("* Explosion *");
            SendMessage("What happened? I though it would finally work.");
            SendMessage("Alright, lets head back to the garage and see if I can fix it.");
            Dialogue.Instance.OnComplete = () => { 
                Properties.SetText("Head to the garage.");
                Properties.Explosion = true;
                Locked = false; 
                return true; 
            };
            return false;
        };
    }

    public void ExitTimeTravel() {
        Locked = true;
        SendMessage("...");
        SendMessage("WHAT!?");
        SendMessage("Where am I?");
        SendMessage("Is... that... a... DINOSAUR?!");
        SendMessage("I need to get out of here.");
        SendMessage("Although, I am pretty hungry, I need to find some food");
        SendMessage("Lets go and collect some berries to eat.");
        Dialogue.Instance.OnComplete = () => { 
            Properties.SetText("Find berries to eat."); 
            Locked = false; 
            return true; 
        };
    }

    public void DiscoverMissingBatteries() {
        Locked = true;
        SendMessage("... now the batteries are missing.");
        SendMessage("Well this is just brilliant...");
        SendMessage("I guess we have to go and search for them.");
        Dialogue.Instance.OnComplete = () => {
            Properties.BatteriesDino.Value = 4;
            Locked = false;
            return true;
        };
    }

    public new void SendMessage(string message) {
        Debug.Log(message);
        Dialogue.Instance.DisplayText = message;
    }
}
