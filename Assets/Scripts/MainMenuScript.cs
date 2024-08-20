using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    [SerializeField] GameObject aboutPanel;

    public void onNewGameButton() {
        SceneManager.LoadSceneAsync("Level-1");
    }

    public void onAboutButton() {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }
}
