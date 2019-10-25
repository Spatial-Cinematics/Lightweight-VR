using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {
    [SerializeField] 
    private MeshRenderer hitBox;
    
    public float speed = 1;
    private void Update() {
        
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        
    }

    private void Start() {
        Destroy(gameObject, 5);
    }

    public void SetMat(Material newMat) {
        hitBox.material = newMat;
    }
    
}
