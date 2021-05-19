using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
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
}
