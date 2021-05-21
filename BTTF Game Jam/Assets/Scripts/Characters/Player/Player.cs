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

    public void PickupBerry() {
        Properties.Berries.Value--;
    }

    [SerializeField]
    private GameObject berryWaypoint;
    [SerializeField]
    private GameObject oldPower;
    [SerializeField]
    private GameObject newPower;

    public void BerryComplete() {
        berryWaypoint.SetActive(true);
        oldPower.SetActive(false);
        newPower.SetActive(true);
    }

    [SerializeField]
    private GameObject garage;
    [SerializeField]
    private GameObject dinoLand;
    [SerializeField]
    private GameObject redLights;
    [SerializeField]
    private GameObject blueLights;

    public void TimeTravelPad(Position pad) {
        if (Properties.Finished) {
            return;
        }
        if (Properties.Explosion) {
            TimeTravelStageTwo(pad);
        } else {
            TimeTravelStageOne(pad);
        }
    }

    public void TimeTravelStageTwo(Position pad) {
        if (Properties.BatteriesPlaced.Value > 0 || Properties.BatteriesDino.Value > 0) {
            SendMessage("Looks like this device needs power.");
            return;
        }

        Locked = true;
        Position.Set(pad.Get() + new Vector3(0, 0.25f, 0));
        timeTravelBeam.SetActive(true);
        SendMessage("Lets hope it works this time.");
        SendMessage("Back to the future!");
        SendMessage("Lets go investigate our success.");
        Dialogue.Instance.OnComplete = () => {
            timeTravelBeam.SetActive(false);
            dinoLand.SetActive(false);
            garage.SetActive(true);
            endingWaypoint.SetActive(true);
            Properties.SetText("Check the garage.");
            Properties.Finished = true;
            Locked = false;
            return true;
        };
    }

    [SerializeField]
    private GameObject endingWaypoint;

    public void EndingDialogue() {
        Locked = true;
        SendMessage("It worked! Thank goodness for that.");
        SendMessage("We seem to be safely back at the garage.");
        Dialogue.Instance.OnComplete = () => {

            return true;
        };
    }

    [SerializeField]
    private GameObject timeTravelBeam;

    public void TimeTravelStageOne(Position pad) {
        if (Properties.BatteriesPlaced.Value > 0) {
            SendMessage("Looks like this device needs power.");
            return;
        }

        Locked = true;
        Position.Set(pad.Get() + new Vector3(0, 0.25f, 0));
        timeTravelBeam.SetActive(true);
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
            SendMessage("What happened? I thought it would finally work.");
            SendMessage("Alright, lets head back to the garage and see if I can fix it.");
            Dialogue.Instance.OnComplete = () => {
                timeTravelBeam.SetActive(false);
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
        SendMessage("GREAT SCOTT!");
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

    [SerializeField]
    private GameObject missingBatteries;

    public void DiscoverMissingBatteries() {
        Locked = true;
        SendMessage("... now the batteries are missing.");
        SendMessage("Well this is just brilliant...");
        SendMessage("I guess I have to go and search for them.");
        Dialogue.Instance.OnComplete = () => {
            missingBatteries.SetActive(true);
            Properties.BatteriesDino.Value = 4;
            Locked = false;
            return true;
        };
    }

    public void SecondBatteries() {
        redLights.SetActive(false);
        blueLights.SetActive(true);
    }

    public new void SendMessage(string message) {
        Debug.Log(message);
        Dialogue.Instance.DisplayText = message;
    }
}
