using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VRButton {RightIndex, RightHand, RightThumbHorizontal, RightThumbVertical, RightThumbClick, 
    LeftIndex, LeftHand, LeftThumbHorizontal, LeftThumbVertical, LeftThumbClick, A, B, X, Y, Menu, Home}

public enum GenericVRButton{Index, Hand, ThumbClick, ThumbVertical, ThumbHorizontal}

public class VRInput : MonoBehaviour {

    private VRButton[] axesThatAreButtons = {
        VRButton.RightHand, VRButton.LeftHand,
        VRButton.RightIndex, VRButton.LeftIndex
    };

    private Dictionary<VRButton, bool> axesInUse;

    public delegate void OnButtonCallback(VRButton button);
    public static OnButtonCallback OnButton;

    private void Start() {
        
        axesInUse = new Dictionary<VRButton, bool>();
        foreach (VRButton axis in axesThatAreButtons) {
            axesInUse.Add(axis, false);
        }
    }
    
    private void Update() {
        
        foreach (VRButton axis in axesThatAreButtons) {

            if (Input.GetAxisRaw(axis.ToString()) > 0) {
                print(axis + " down");
                if (!axesInUse[axis]) {
                    OnButton.Invoke(axis);
                    axesInUse[axis] = true;
                }
            }

            if (Input.GetAxisRaw(axis.ToString()) > 0) {
                axesInUse[axis] = false;
            }
            
        }
        
    }

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

}

