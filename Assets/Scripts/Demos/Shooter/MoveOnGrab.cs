using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnGrab : MonoBehaviour {
    
    Vector3 dir = Vector3.down;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float destroyThreshold = 5;

    private Vector3 startPos;
    
    public void Move() {

        startPos = transform.position;
        StartCoroutine(LoopMove());

    }

    IEnumerator LoopMove() {

        while (true) {
            transform.Translate(dir * Time.deltaTime * speed);
            if (transform.position.Distance(startPos) > destroyThreshold)
                Destroy(gameObject);
            yield return null;
        }
        
    }
    
}
