using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour {

    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float rotateDegrees = 90;
    [SerializeField]
    private VRAxis2D moveInput = VRAxis2D.LeftThumb;
    [SerializeField]
    private VRAxis turnInput = VRAxis.RightThumbHorizontal;
    [SerializeField]
    private Vector3 walkablePlaneNormal = Vector3.up;
    
    private Transform playerHead;
    private Transform trackingSpace;
    
    private void Start() {
        playerHead = Camera.main.transform;
        trackingSpace = playerHead.parent;
    }

    private void Update() {

        MovePlayer();
        TurnPlayer();

    }

    private void MovePlayer() {
        Vector2 velocity = VRInput.GetAxis2D(moveInput); //velocity input
        //Vector3 delta = new Vector3(heading.x * velocity.x, 0, heading.z * velocity.y);
        Vector3 deltaForward = playerHead.forward.WithValues(y:0) * velocity.y;
        Vector3 deltaRight = playerHead.right.WithValues(y:0) * velocity.x;
        Vector3 delta = deltaRight + deltaForward;
        Vector3 newPos = transform.position + delta * speed * Time.deltaTime;
        transform.position = newPos;
    }
    
    private void TurnPlayer() {
            float turnValue = VRInput.GetAxisOnce(turnInput); //axis equiv. to GetDown
            transform.RotateAround(playerHead.position, Vector3.up, rotateDegrees * turnValue);
    }
    
}
