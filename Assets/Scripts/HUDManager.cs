using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject serumCounter;

    private PlayerCapabilities playerCapabilities;
    private TextMeshProUGUI textComponent;

    void Start() {
        textComponent = serumCounter.GetComponent<TextMeshProUGUI>();
        playerCapabilities = player.GetComponent<PlayerCapabilities>();
    }

    void Update() {
        textComponent.text = playerCapabilities._numSerums.ToString();
    }
}
