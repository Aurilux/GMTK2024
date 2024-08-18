using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    // Start is called before the first frame update
    TextMeshPro textComponent;
    [SerializeField] PlayerCapabilities playerCapabilities;

    void Start() {
        textComponent = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update() {
        textComponent.text = playerCapabilities._numSerums.ToString();
    }
}
