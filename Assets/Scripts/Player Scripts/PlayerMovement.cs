using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 0.025f;
    public GameObject bulletPrefab;

    public ParticleSystem boomPrefab;


    void processMovement() {
        if ((Input.GetKey("left") || Input.GetKey("a")) && (transform.position.x > -8)){
            transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
        }
        if ((Input.GetKey("right") || Input.GetKey("d")) && (transform.position.x < 8)){
            transform.position = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void processShooting() {
        if (Input.GetKeyDown("space")) {  // This is more flexible than hardcoding "space"
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
    }

    void Update() {
        // Process player movement
        processMovement();

        // Process player shooting
        processShooting();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag != "PlayerBullet"){
            Destroy(gameObject);
            Instantiate(boomPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            ScreenShake.setStart(true);
            boomPrefab.Play();
            FindObjectOfType<GameManager>().endGame();
        }
    }
}
