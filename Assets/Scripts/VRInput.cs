using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public enum VRButton {RightIndex, RightHand, LeftIndex, LeftHand, 
     RightThumbClick, LeftThumbClick, A, B, X, Y, Menu, Home}

public enum VRAxis {RightIndex, RightHand, LeftIndex, LeftHand,
    LeftThumbHorizontal, LeftThumbVertical, RightThumbHorizontal, RightThumbVertical}

public enum GenericVRAxis {ThumbVertical, ThumbHorizontal}

public enum VRAxis2D {RightThumb, LeftThumb}

public enum GenericVRAxis2D {Thumb}

public enum GenericVRButton{Index, Hand, ThumbClick}

public class VRInput : MonoBehaviour {

    #region properties
    
    private VRAxis[] axesThatAreButtons = {
        VRAxis.RightHand, VRAxis.LeftHand,
        VRAxis.RightIndex, VRAxis.LeftIndex
    };

    private static Dictionary<VRAxis, bool> axisAvailable = new Dictionary<VRAxis, bool>() {
        {VRAxis.LeftHand, false}, {VRAxis.RightHand, false}, 
        {VRAxis.LeftIndex, false}, {VRAxis.RightIndex, false}
    };
    
    private static Dictionary<VRAxis, bool> axisWasBeingHeld = new Dictionary<VRAxis, bool>() {
        {VRAxis.LeftHand, false}, {VRAxis.RightHand, false}, 
        {VRAxis.LeftIndex, false}, {VRAxis.RightIndex, false}
    };
    
    #endregion
    
    //reset input flags
    private void Update() {
        foreach (VRAxis axis in axesThatAreButtons) {
            if (Input.GetAxisRaw(axis.ToString()) <= 0) //input axis not being recieved
                axisAvailable[axis] = true; //next input should be unique - GetDown can be called
            else { //input is being recieved
                axisWasBeingHeld[axis] = true; //next input should be unique - GetUp can be called
            }
        }
    }
    
    #region methods

    public static float GetAxis(VRAxis input) {
        return Input.GetAxis(input.ToString());
    }

    public static float GetAxis(GenericVRAxis input, Handedness handedness) {

        if (handedness == Handedness.None) {
            Debug.LogError("Handedness not set");
            return 0;
        }
        
        return Input.GetAxis(handedness.ToString() + input.ToString());
        
    }

    public static Vector2 GetAxis2D(VRAxis2D input) {

        float x = Input.GetAxis(input + "Horizontal");
        float y = Input.GetAxis(input + "Vertical");

        return new Vector2(x,y);
        
    }

    public static Vector2 GetAxis2D(VRAxis2D input, Handedness handedness) {
        
        float x = Input.GetAxis(handedness.ToString() + input + "Horizontal");
        float y = Input.GetAxis(handedness.ToString() + input + "Vertical");

        return new Vector2(x,y);
        
    }
    
    public static float GetAxisRaw(VRAxis input) {
        return Input.GetAxisRaw(input.ToString());
    }

    public static float GetAxisRaw(GenericVRAxis input, Handedness handedness) {

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

        //if cast results in different value then inputs are mutually exclusive
        VRAxis axisInput = (VRAxis) input;

        if (axisInput.ToString() == input.ToString()) { //input is also an axis

            if (GetAxisRaw(axisInput) > 0) {
                //input recieved
                if (axisAvailable[axisInput]) {
                    //input is new (wasn't previously being held
                    axisAvailable[axisInput] = false;
                    return true;
                }
            }
        } else //input is a button
             return Input.GetButtonDown(input.ToString());

        return false;

    }
    public static bool GetDown(GenericVRButton input, Handedness handedness) {

        VRButton vrButton = (VRButton)Enum.Parse(typeof(VRButton), handedness.ToString() + input.ToString());
        return GetDown(vrButton);

    }
    
    public static bool GetUp(VRButton input) {

        VRAxis axisInput = (VRAxis) input;

        if (axisInput.ToString() == input.ToString()) {
            //input is also an axis
            if (GetAxisRaw(axisInput) <= 0) {
                //input not recieved
                if (axisWasBeingHeld[axisInput]) {
                    //input is new (wasn't previously being held
                    axisWasBeingHeld[axisInput] = false;
                    return true;
                }
            }
        } else {
            return Input.GetButtonUp(input.ToString());
        }

        return false;

    }
    public static bool GetUp(GenericVRButton input, Handedness handedness) {

        VRButton vrButton = (VRButton)Enum.Parse(typeof(VRButton), handedness.ToString() + input.ToString());
        return GetUp(vrButton);

    }
    
    #endregion

}

