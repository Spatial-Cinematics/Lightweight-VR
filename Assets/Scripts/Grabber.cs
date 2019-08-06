using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Grabber : MonoBehaviour {

    [HideInInspector]
    public Transform grabbedTransform;
    public Handedness handedness;

    [SerializeField]
    private List<Transform> inRange = new List<Transform>();
    private Rigidbody rb;
    private float grabThreshold = .5f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //check input for this hand instance
        float grabValue = handedness == Handedness.Left ? VRInput.Get(VRButton.LeftHand) : VRInput.Get(VRButton.RightHand);

        if (grabValue > grabThreshold) { //grab input
            if (!grabbedTransform)
                Grab();
        }
        else if (grabbedTransform) { //no grab input and item is being held
                Drop();
        }

    }
    
    //create list of grabbable transforms in range of hand
    private void OnTriggerEnter(Collider other) {

        Grabbable grabbable = other.GetComponent<Grabbable>();
        
        if (!grabbable)
            return;
        
        inRange.Add(grabbable.transform);
        
    }

    private void OnTriggerExit(Collider other) {
        
        Grabbable grabbable = other.GetComponent<Grabbable>();
        
        if (!grabbable)
            return;

        inRange.Remove(grabbable.transform);

    }

    private void Grab() {
        
            //closest grabbable transform out of in range grabbable transforms
            Transform closest = null;
            
            //find closest
            if (inRange.Count > 0) {
                closest = inRange.Aggregate((i1, i2) =>
                    transform.Distance(i1) < transform.Distance(i2) ? i1 : i2);
            }

            if (closest) { // an item is in range - pick it up
                grabbedTransform = closest;
                closest.GetComponent<Grabbable>().OnGrab(this);
            }
        
    }

    public void Drop() {
        
        if (!grabbedTransform)
            return;
        
        grabbedTransform.GetComponent<Grabbable>().OnDrop(this);
        
    }
    
}