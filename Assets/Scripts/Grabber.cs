using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(SphereCollider))]
public class Grabber : MonoBehaviour {

    [HideInInspector]
    public Transform grabbedTransform;
    public Handedness handedness;

    [SerializeField, HideInInspector]
    private List<Transform> inRange = new List<Transform>();
    private Rigidbody rb;
    [SerializeField]
    private float inputThreshold = .5f; // pulled half way

    private float indexInput, handInput;

    public GameObject deleteThisPrefab;
    
    #region Reference Grabable Items

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

    #endregion
    
    private void Start() {
        
        rb = GetComponent<Rigidbody>();

    }

    private void Update() {
        
        if (VRInput.GetDown(GenericVRButton.Hand, handedness)) {
            Grab();
        } else if (VRInput.GetUp(GenericVRButton.Hand, handedness)) {
            Drop();
        }
        
    }


    private void UseGrabbed() {
        grabbedTransform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
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