using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerProperties {
    [SerializeField]
    public float MovementSpeed { get; private set; } = 10;
    public ChangeListener<int> Batteries { get; private set; } = new ChangeListener<int>(4);
    public ChangeListener<int> BatteriesPlaced { get; private set; } = new ChangeListener<int>(4);

    public bool Explosion { get; set; }

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
            }
        };
    }

    private void Reset() { 
        
    }
}
