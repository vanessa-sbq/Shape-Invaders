using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Rigidbody2D rb;

    public ParticleSystem boomPrefab;
    public float cooldownDuration = 2f;
    private float elapsedTime;
    private float startTime;
    public float cooldownMaxDuration;
    public float cooldownMinDuration;
    public GameObject enemyBulletPrefab;

    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        startTime = Time.time;
        float randomNumber = Random.Range(cooldownMinDuration, cooldownMaxDuration + 1f); // Generates between 2 and 4
        cooldownDuration =  randomNumber; // Randomize cooldown
    }

    void Update() {
        elapsedTime = Time.time - startTime;

        if (elapsedTime >= cooldownDuration) {
            startTime = Time.time;
            elapsedTime = 0; // Reset timer
            shootOrNotShoot();
            float randomNumber = Random.Range(cooldownMinDuration, cooldownMaxDuration + 1f); // Generates between 2 and 4
            cooldownDuration =  randomNumber; // Randomize cooldown
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag != "EnemyBullet"){
            Destroy(gameObject);
            Instantiate(boomPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            ScreenShake.setStart(true);
            boomPrefab.Play();
        }
    }

    void shootOrNotShoot() {
        int randomNumber = Random.Range(0, 2); // Generates 0 or 1
        if (randomNumber == 1){
            Instantiate(enemyBulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
    }

}
