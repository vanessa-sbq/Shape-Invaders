using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemyMovScript : MonoBehaviour {
    private float enemyOriginX; // Position from where the enemy starts
    public float enemySpeed = 0.07f;
    public float enemyMovementSpace = 2f; // Width of movement
    private bool goToRight = false; // Initially enemy moves to the left

    private bool goDown = false;


    void Start() {
        enemyOriginX = transform.position.x;
    }


    // Update is called once per frame
    void Update() {
        moveEnemies();
    }


    void moveEnemies(){ 
        if (transform.position.x <= enemyOriginX - (enemyMovementSpace / 2)){
            if (!goToRight) goDown = true;
        }
        else if (transform.position.x >= enemyOriginX + (enemyMovementSpace / 2)){
            if (goToRight) goDown = true;
        }

        if (goDown){
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
            goDown = false;
            goToRight = !goToRight;
        }

        int direction = goToRight ? 1 : -1;
        transform.position = new Vector2(transform.position.x + direction * enemySpeed * Time.deltaTime, transform.position.y);
    }
}
