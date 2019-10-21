using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other) {
        other.GetComponent<Enemy>();
        if (other.GetComponent<Enemy>()) {
            other.GetComponent<Enemy>().OnHit();
        }
    }
}
