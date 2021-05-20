using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharger : MonoExtension {
    private static Lock<GameObject> ACTIVE_CHARGER = new Lock<GameObject>();

    private void Awake() {
        if (ACTIVE_CHARGER == null) {
            return;
        }
        ACTIVE_CHARGER.Value = TryLoad<GameObject>("BatteryChargerActive");
    }

    public void PlaceBattery() {
        Player player = Game.Player;

        if (player.Properties.Batteries.Value > 0) {
            player.SendMessage("You need to collect the batteries first!");
            return;
        }

        player.Properties.BatteriesPlaced.Value--;

        GameObject obj = TryCreate(ACTIVE_CHARGER.Value);
        obj.transform.parent = transform.parent;
        obj.transform.position = transform.position;
        Destroy();
    }
}
