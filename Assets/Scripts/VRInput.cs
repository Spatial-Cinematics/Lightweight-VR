using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VRButton {RightIndex, RightHand, RightThumbHorizontal, RightThumbVertical, RightThumbClick, 
    LeftIndex, LeftHand, LeftThumbHorizontal, LeftThumbVertical, LeftThumbClick, A, B, X, Y, Menu, Home}

public class VRInput : MonoBehaviour {

    public static float Get(VRButton input) {
        return Input.GetAxis(input.ToString());
    }

    public static bool GetOnce(VRButton input) {
        return Input.GetAxis(input.ToString()) > 0;
    }
}

