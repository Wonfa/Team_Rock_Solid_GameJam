using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField]
    private string gameScene;

    [SerializeField]
    private string menuScene;

    public void OpenGameScene() {
        SceneManager.LoadScene(gameScene);
    }
    public void OpenMenuScene() {
        SceneManager.LoadScene(menuScene);
    }
    public void Quit() {
        Application.Quit();
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name.Equals(menuScene)) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OpenMenuScene();
        }
    }
}
