using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour {
    public float movementSpeed = 10f;
    public float leftBound = -10;
    public float rightBound = 10;
    public float upperBound = 10;
    public float lowerBound = -10;


    bool IsOutOfBounds() {
        return transform.position.x < leftBound || transform.position.x > rightBound ||
               transform.position.y > upperBound || transform.position.y < lowerBound;
    }


    void Update() {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;

        // Check bounds and destroy the bullet if it goes out of bounds
        if (IsOutOfBounds()) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
    }

}
