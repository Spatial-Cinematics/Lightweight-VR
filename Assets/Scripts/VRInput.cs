using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour {
   
    public static float RightIndex() {
        return Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger");
    }
    public static float LeftIndex() {
        return Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger");
    }
    public static float RightHand() {
        return Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger");
    }
    public static float LeftHand() {
        return Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger");
    }

    public static float RightThumbHorizontal() {
        return Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
    }
    
    public static float RightThumbVertical() {
        return Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
    }
    
    public static float LeftThumbHorizontal() {
        return Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
    }
    
    public static float LeftThumbVertical() {
        return Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");
    }

    public static bool A() {
        return Input.GetButton("Oculus_CrossPlatform_A");
    }
    
    public static bool B() {
        return Input.GetButton("Oculus_CrossPlatform_B");
    }
    
    public static bool X() {
        return Input.GetButton("Oculus_CrossPlatform_X");
    }
    
    public static bool Y() {
        return Input.GetButton("Oculus_CrossPlatform_Y");
    }
    
    public static bool RightThumbClick() {
        return Input.GetButton("Oculus_CrossPlatform_RightThumbClick");
    }
    
    public static bool LeftThumbClick() {
        return Input.GetButton("Oculus_CrossPlatform_LeftThumbClick");
    }
    
}



public struct Gesture {
    private string key;
}
