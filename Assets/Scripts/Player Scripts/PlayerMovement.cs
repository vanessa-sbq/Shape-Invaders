using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 0.025f;
    public GameObject bulletPrefab;

    void processMovement() {
        if (Input.GetKey("left")){
            transform.position = new Vector2(transform.position.x - movementSpeed, transform.position.y);
        }
        if (Input.GetKey("right")){
            transform.position = new Vector2(transform.position.x + movementSpeed, transform.position.y);
        }
        /* if (Input.GetKey("up")){
            transform.position = new Vector2(transform.position.x, transform.position.y + movementSpeed);
        }
        if (Input.GetKey("down")){
            transform.position = new Vector2(transform.position.x, transform.position.y - movementSpeed);
        } */
    }

    void processShooting() {
        if (Input.GetKeyDown("space")) {  // This is more flexible than hardcoding "space"
            if (bulletPrefab != null) {
                Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            } else {
                Debug.LogWarning("Bullet prefab is not assigned.");
            }
        }
    }

    void Update() {
        // Process player movement
        processMovement();

        // Process player shooting
        processShooting();
    }
}
