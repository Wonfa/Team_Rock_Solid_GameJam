using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerProperties {
    [SerializeField]
    private float movementSpeed = 10;
    public float MovementSpeed { get => movementSpeed; private set { } }
    public ChangeListener<int> Batteries { get; private set; } = new ChangeListener<int>(4);
    public ChangeListener<int> BatteriesPlaced { get; private set; } = new ChangeListener<int>(4);
    public ChangeListener<int> BatteriesDino { get; private set; } = new ChangeListener<int>(4);
    public ChangeListener<int> Berries { get; private set; } = new ChangeListener<int>(3);

    public bool Explosion { get; set; }

    public bool Finished { get; set; }

    public void Init() {
        Setup();
        Batteries.OnChange?.Invoke();
        Explosion = false;
    }

    [SerializeField]
    private Text questText;

    private void Setup() {
        Batteries.OnChange += () => questText.text = "Collect " + Batteries.Value.ToString() + " batteries.";
        Batteries.OnChange += () => {
            if (Batteries.Value <= 0) {
                questText.text = string.Empty;
                BatteriesPlaced.Value = 4;
            }
        };
        BatteriesPlaced.OnChange = () => questText.text = "Deliver " + BatteriesPlaced.Value.ToString() + " batteries to chargers.";
        BatteriesPlaced.OnChange += () => {
            if (BatteriesPlaced.Value <= 0) {
                questText.text = "Stand on time travel pad.";
                if (Explosion) {
                    Game.Player.SecondBatteries();
                }
            }
        };
        BatteriesDino.OnChange += () => questText.text = "Search for " + BatteriesDino.Value.ToString() + " batteries.";
        BatteriesDino.OnChange += () => {
            if (BatteriesDino.Value <= 0) {
                questText.text = string.Empty;
                BatteriesPlaced.Value = 4;
            }
        };
        Berries.OnChange += () => questText.text = "Search for " + Berries.Value.ToString() + " berries.";
        Berries.OnChange += () => {
            if (Berries.Value <= 0) {
                questText.text = "Return indoors.";
                Game.Player.BerryComplete();
            }
        };
    }

    public void SetText(string text) {
        questText.text = text;
    }

    private void Reset() {
        BatteriesPlaced.Value = 0;
        BatteriesDino.Value = 4;
    }
}
