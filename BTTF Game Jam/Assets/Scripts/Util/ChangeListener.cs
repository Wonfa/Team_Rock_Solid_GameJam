using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeListener<T> {
    public Action OnChange { get; set; }

    private T value;
    public T Value { get => value; set { this.value = value; OnChange?.Invoke(); } }

    public ChangeListener(T value) {
        this.value = value;
    }
}
