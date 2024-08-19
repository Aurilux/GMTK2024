using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    [SerializeField] public bool isJekyllInteractable = false;
    [SerializeField] public bool isHydeInteractable = false;

    public abstract void onInteract();
}
