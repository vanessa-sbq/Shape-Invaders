using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public ParticleSystem boomPrefab;
    
    public float enemySpeed = 0.07f;

    public float enemyMovementSpace = 2f; // Width of movement

    private bool goToRight = false; // Initially enemy moves to the left

    private float enemyOriginX; // Position from where the enemy starts


    void Start() {
        enemyOriginX = transform.position.x;
    }

    // Update is called once per frame
    void Update(){
        moveEnemy();
    }

    // Check if enemy was hit
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Instantiate(boomPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        ScreenShake.setStart(true);
        boomPrefab.Play();
    }

    // Enemy moves side to side
    void moveEnemy(){ 
        if (transform.position.x <= enemyOriginX - (enemyMovementSpace / 2)){
            goToRight = true;
        }
        else if (transform.position.x >= enemyOriginX + (enemyMovementSpace / 2)){
            goToRight = false;
        }
        Debug.Log(enemyMovementSpace + "      " + enemyOriginX);

        int direction = goToRight ? 1 : -1;
        transform.position = new Vector2(transform.position.x + direction * enemySpeed, transform.position.y);
    }

}
