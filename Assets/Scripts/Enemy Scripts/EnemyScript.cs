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
    public GameObject enemyBulletPrefab;

    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        startTime = Time.time;
    }

    void Update() {
        elapsedTime = Time.time - startTime;

        if (elapsedTime >= cooldownDuration) {
            startTime = Time.time;
            elapsedTime = 0; // Reset timer
            shootOrNotShoot();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
        Instantiate(boomPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        ScreenShake.setStart(true);
        boomPrefab.Play();
    }

    void shootOrNotShoot() {
        Debug.Log(gameObject + " Shot!");
        //Instantiate(enemyBulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

}
