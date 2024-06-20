using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Rigidbody2D rb;

    public ParticleSystem boomPrefab;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
        Instantiate(boomPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        ScreenShake.setStart(true);
        boomPrefab.Play();
    }

}
