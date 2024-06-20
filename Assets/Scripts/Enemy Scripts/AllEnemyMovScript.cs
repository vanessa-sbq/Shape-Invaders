using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemyMovScript : MonoBehaviour {


    private float enemyOriginX; // Position from where the enemy starts
    public float enemySpeed = 0.07f;
    public float enemyMovementSpace = 2f; // Width of movement
    private bool goToRight = false; // Initially enemy moves to the left


    void Start() {
        enemyOriginX = transform.position.x;
    }


    // Update is called once per frame
    void Update() {
        moveEnemies();
    }


    void moveEnemies(){ 
        if (transform.position.x <= enemyOriginX - (enemyMovementSpace / 2)){
            goToRight = true;
        }
        else if (transform.position.x >= enemyOriginX + (enemyMovementSpace / 2)){
            goToRight = false;
        }

        int direction = goToRight ? 1 : -1;
        transform.position = new Vector2(transform.position.x + direction * enemySpeed, transform.position.y);
    }
}
