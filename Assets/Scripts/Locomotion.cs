using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour {

    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private VRAxis2D moveInput = VRAxis2D.LeftThumb;

    private Transform playerHead;
    
    private void Start() {
        playerHead = Camera.main.transform;
    }

    private void Update() {

        Vector2 v = VRInput.GetAxis2D(moveInput);
        Vector3 heading = playerHead.localRotation.eulerAngles;
        Vector3 velocity = new Vector3(v.x * heading.x, 0, v.y * heading.z);


        transform.position += velocity * speed * Time.deltaTime;

    }
}
