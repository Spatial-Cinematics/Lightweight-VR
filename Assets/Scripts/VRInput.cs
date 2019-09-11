using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VRButton {RightIndex, RightHand, RightThumbHorizontal, RightThumbVertical, RightThumbClick, 
    LeftIndex, LeftHand, LeftThumbHorizontal, LeftThumbVertical, LeftThumbClick, A, B, X, Y, Menu, Home}

public enum GenericVRButton{Index, Hand, ThumbClick, ThumbVertical, ThumbHorizontal}

public class VRInput : MonoBehaviour {

    #region properties
    
    private VRButton[] axesThatAreButtons = {
        VRButton.RightHand, VRButton.LeftHand,
        VRButton.RightIndex, VRButton.LeftIndex
    };

    private static Dictionary<VRButton, bool> axesGet = new Dictionary<VRButton, bool>() {
        {VRButton.LeftHand, false}, {VRButton.RightHand, false}, 
        {VRButton.LeftIndex, false}, {VRButton.RightIndex, false}
    };
    
    #endregion
    
    //reset input flags
    private void LateUpdate() {
        foreach (VRButton axis in axesThatAreButtons) 
            if (Input.GetAxisRaw(axis.ToString()) > 0) //input axis not being recieved
                axesGet[axis] = false; //next input should be unique - GetDown can be called
    }
    
    #region methods

    public static float GetAxis(VRButton input) {
        return Input.GetAxis(input.ToString());
    }

    public static float GetAxis(GenericVRButton input, Handedness handedness) {

        if (handedness == Handedness.None) {
            Debug.LogError("Handedness not set");
            return 0;
        }
        
        return Input.GetAxis(handedness.ToString() + input.ToString());
        
    }
    
    public static float GetAxisRaw(VRButton input) {
        return Input.GetAxisRaw(input.ToString());
    }

    public static float GetAxisRaw(GenericVRButton input, Handedness handedness) {

        if (handedness == Handedness.None) {
            Debug.LogError("Handedness not set");
            return 0;
        }
        
        return Input.GetAxisRaw(handedness.ToString() + input.ToString());
        
    }

    public static bool Get(VRButton input) {
        return Input.GetAxisRaw(input.ToString()) > 0;
    }
    
    public static bool Get(GenericVRButton input, Handedness handedness) {

        if (handedness == Handedness.None) {
            Debug.LogError("Handedness not set");
            return false;
        }
        
        return Math.Abs(Input.GetAxisRaw(handedness.ToString() + input.ToString())) > 0;

    }

    public static bool GetDown(VRButton input) {
        
        if (GetAxisRaw(input) > 0) { //input recieved
            print(input + " held");
            if (!axesGet[input]) { //input is new (wasn't previously being held
                print(input + " pressed");
                axesGet[input] = true;
                return true;
            }
        }

        return false;

    }
    
    #endregion

}

