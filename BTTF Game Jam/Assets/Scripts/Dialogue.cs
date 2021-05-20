using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public static Dialogue Instance { get; private set; }

    [SerializeField]
    private Text text;

    public Func<bool> OnComplete { get; set; }

    private float resetTime;
    private Queue<string> queue;

    public string DisplayText { 
        get => text.text; 
        set {
            if (text.text == value || queue.Contains(value)) {
                return;
            }
            if (text.text == string.Empty) {
                text.text = value;
                resetTime = Time.time + value.Split(' ').Length * 0.6f;
            } else {
                queue.Enqueue(value);
            }
        }
    }

    private void Awake() {
        Instance = this;
        queue = new Queue<string>();
    }

    private void Update() {
        if (resetTime > Time.time) {
            return;
        }

        if (queue.Count == 0) {
            if (text.text != string.Empty) {
                text.text = string.Empty;
                if (OnComplete?.Invoke() ?? true) {
                    OnComplete = null;
                }
            }
            return;
        }

        string value = queue.Dequeue();
        text.text = value;
        resetTime = Time.time + value.Split(' ').Length * 0.6f;
    }
}
