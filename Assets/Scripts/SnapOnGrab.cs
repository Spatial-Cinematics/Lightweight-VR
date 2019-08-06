using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grabbable))]
public class SnapOnGrab : MonoBehaviour {
    
    private Grabbable grabComponent;
    
    [HideInInspector] 
    public Vector3 snapPosition;
    [HideInInspector] 
    public Quaternion snapOrientation;

    private void Start() {
        grabComponent = GetComponent<Grabbable>();
    }

    public void Snap() {
      //  bool isRightHanded = myGrabber is RightGrabber;
      //  transform.localPosition = isRightHanded ? snapPositionR : snapPositionL;
     //   transform.localRotation = isRightHanded ? snapOrientationR : snapOrientationL;
    //    rb.velocity = Vector3.zero;
     //   rb.angularVelocity = Vector3.zero;

     transform.localPosition = snapPosition;
     transform.localRotation = snapOrientation;

    }

    
}
