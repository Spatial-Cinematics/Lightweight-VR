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

    private static Dictionary<VRButton, bool> axisAvailable = new Dictionary<VRButton, bool>() {
        {VRButton.LeftHand, false}, {VRButton.RightHand, false}, 
        {VRButton.LeftIndex, false}, {VRButton.RightIndex, false}
    };
    
    private static Dictionary<VRButton, bool> axisWasBeingHeld = new Dictionary<VRButton, bool>() {
        {VRButton.LeftHand, false}, {VRButton.RightHand, false}, 
        {VRButton.LeftIndex, false}, {VRButton.RightIndex, false}
    };
    
    #endregion
    
    //reset input flags
    private void Update() {
        foreach (VRButton axis in axesThatAreButtons) {
            if (Input.GetAxisRaw(axis.ToString()) <= 0) //input axis not being recieved
                axisAvailable[axis] = true; //next input should be unique - GetDown can be called
            else { //input is being recieved
                axisWasBeingHeld[axis] = true; //next input should be unique - GetUp can be called
            }
        }
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
            if (axisAvailable[input]) { //input is new (wasn't previously being held
                axisAvailable[input] = false;
                return true;
            }
        }

        return false;

    }
    public static bool GetDown(GenericVRButton input, Handedness handedness) {

        VRButton vrButton = (VRButton)Enum.Parse(typeof(VRButton), handedness.ToString() + input.ToString());
        return GetDown(vrButton);

    }
    
    public static bool GetUp(VRButton input) {
        
        if (GetAxisRaw(input) <= 0) { //input not recieved
            if (axisWasBeingHeld[input]) { //input is new (wasn't previously being held
                axisWasBeingHeld[input] = false;
                return true;
            }
        }

        return false;

    }
    public static bool GetUp(GenericVRButton input, Handedness handedness) {

        VRButton vrButton = (VRButton)Enum.Parse(typeof(VRButton), handedness.ToString() + input.ToString());
        return GetUp(vrButton);

    }
    
    #endregion

}

