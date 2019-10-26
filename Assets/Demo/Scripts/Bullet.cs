using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10;
    public float force = 5;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other) {

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb) {
            rb.velocity = rb.velocity + transform.forward * force;
        }
        
    }
}
