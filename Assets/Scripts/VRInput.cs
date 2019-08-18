using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VRButton {RightIndex, RightHand, RightThumbHorizontal, RightThumbVertical, RightThumbClick, 
    LeftIndex, LeftHand, LeftThumbHorizontal, LeftThumbVertical, LeftThumbClick, A, B, X, Y, Menu, Home}

public enum GenericVRButton{Index, Hand, ThumbClick, ThumbVertical, ThumbHorizontal}

public class VRInput : MonoBehaviour {

    public static float Get(VRButton input) {
        return Input.GetAxis(input.ToString());
    }

    public static float Get(GenericVRButton input, Handedness handedness) {

        if (handedness == Handedness.None) {
            Debug.LogError("Handedness not set");
            return 0;
        }
        
        return Input.GetAxis(handedness.ToString() + input.ToString());
        
    }
}

