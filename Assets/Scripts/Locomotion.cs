using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour {

    [SerializeField]
    private float  maxSpeed = 2;
    [SerializeField]
    private float acceleration = 1;
    
    private Vector3 velocity = Vector3.zero;
    
    private void Update() {

        Vector3 newVel = Vector3.Lerp(velocity, Vector3.zero, acceleration);

        float x = VRInput.GetAxis(VRButton.LeftThumbHorizontal);
        float z = VRInput.GetAxis(VRButton.LeftThumbVertical);

        print("X: " + x);
        print("Z: " + z);
        
        newVel.x += x;
        newVel.z += z;

        velocity = Vector3.ClampMagnitude(newVel, maxSpeed);
        transform.Translate(velocity * Time.deltaTime);

    }
}
