using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    TextMeshPro textComponent;
    [SerializeField] PlayerCapabilities playerCapabilities;

    void Start() {
        textComponent = GetComponent<TextMeshPro>();
    }

    void Update() {
        textComponent.text = playerCapabilities._numSerums.ToString();
    }
}
