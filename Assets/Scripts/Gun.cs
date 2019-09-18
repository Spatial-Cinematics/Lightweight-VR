using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Gun : MonoBehaviour {
    
    private Handedness handedness;
    private Grabber myGrabber;

    public GameObject bullet;

    private void Start() {
        myGrabber = GetComponent<Grabber>();
        handedness = myGrabber.handedness;
    }

    
    void Update() {

        if (VRInput.GetDown(GenericVRButton.Index, handedness)) {
            Shoot();
        }

    }

    private void Shoot() {
        
        Destroy(Instantiate(bullet, transform.position, transform.rotation), 2f);
        
    }
    
    
}
