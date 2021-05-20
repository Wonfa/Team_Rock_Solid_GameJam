using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoExtension : MonoBehaviour {
    protected T TryGetComponent<T>() {
        T obj = GetComponent<T>();

        if (obj == null) {
            Debug.LogError(gameObject.name + " does not have a " + typeof(T).ToString() + " component.");
        }

        return obj;
    }

    protected GameObject TryCreate(GameObject original) {
        GameObject obj = Instantiate(original);

        if (obj == null) {
            Debug.LogError("Failed to create copy of " + original?.name + ".");
        }

        return obj;
    }

    protected T TryLoad<T>(string path) where T : Object {
        T obj = Resources.Load<T>(path);

        if (obj == null) {
            Debug.LogError("Failed to load " + path + " resource.");
        }

        return obj;
    }
}
