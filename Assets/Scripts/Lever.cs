using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable {
    [SerializeField] public Sprite inactiveImage;
    [SerializeField] public Sprite activeImage;
    
    private SpriteRenderer spriteRenderer;
    private bool isInactive;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = inactiveImage;
        isInactive = true;
    }

    public void onInteract() {
        if (isInactive) {
            spriteRenderer.sprite = activeImage;
        }
        else {
            spriteRenderer.sprite = inactiveImage;
        }
        isInactive = !isInactive;
    }
}
