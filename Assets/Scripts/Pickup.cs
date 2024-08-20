using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    float originalY;

    private float floatStrength = .5f; // You can change this in the Unity Editor to 
                                    // change the range of y positions that are possible.

    void Start() {
        this.originalY = this.transform.position.y;
    }

    void Update() {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
            transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        PlayerCapabilities playerCapabilities = collider.gameObject.GetComponentInParent<PlayerCapabilities>();
        if (playerCapabilities != null) {
            playerCapabilities._numSerums++;
            Destroy(gameObject);
        }
    }
}
