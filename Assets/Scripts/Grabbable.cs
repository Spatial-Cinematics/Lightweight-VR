using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public enum Handedness {None, Left, Right}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour {

    private Grabber myHand;
    private SnapOnGrab snap;

    [HideInInspector]
    public Handedness handedness;
    public bool inputIsDiscrete = true;
    public GenericVRButton useButton = GenericVRButton.Index;
    public UnityEvent onUse;
    public UnityEvent onSpecialGrab;
    public UnityEvent onSpecialDrop;
    public Rigidbody rb { get; private set; }
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        snap = GetComponent<SnapOnGrab>();
    }

    public void OnGrab(Grabber hand) {

        print("Grabbed by: " + hand.name);
        
        //drop from other hand if already being held
        if (myHand)
            OnDrop(myHand);

        transform.parent = hand.transform;
        handedness = hand.handedness;
        myHand = hand;
        rb.isKinematic = true;

        onSpecialGrab?.Invoke();
        
        if (snap) //returns false if snap == null
            snap.Snap();

    }

    public void OnDrop(Grabber hand) {

        
        handedness = Handedness.None;
        myHand = null;
        hand.grabbedTransform = null;
        rb.isKinematic = false;
        transform.parent = null;
        
        onSpecialDrop?.Invoke();
        
    }

    public void CheckForUse() {

        if (inputIsDiscrete && VRInput.GetDown(useButton, handedness)) {
            onUse.Invoke();
        } else if (!inputIsDiscrete && VRInput.Get(useButton, handedness)) {
            onUse.Invoke();
        }
            
        
    }

}