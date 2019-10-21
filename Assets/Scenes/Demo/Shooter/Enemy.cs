using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float speed;
    private float scale;
    private float hitScalar = .5f;
    
    [SerializeField]
    private float deathThreshold = .2f;

    private Transform player;
    
    private void Start() {
        player = Camera.main.transform;
    }

    private void Update() {
        
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            Time.deltaTime * speed);

        if (transform.Distance(player) < .5f)
            SceneManager.LoadScene("Shooter");

    }

    public void OnHit() {

        scale *= hitScalar;
        speed *= hitScalar;
        transform.localScale = Vector3.one * scale;
        if (scale < deathThreshold) {
            Destroy(gameObject);
        }

    }


}
