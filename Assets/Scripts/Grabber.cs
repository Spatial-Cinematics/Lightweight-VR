using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grabber : MonoBehaviour {

    public Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (VRInput.A())
            print("A");
        if (VRInput.B())
            print("B");
        if (VRInput.X())
            print("X");
        if (VRInput.Y())
            print("Y");
        if (VRInput.RightThumbClick())
            print("Right");
        if (VRInput.LeftThumbClick())
            print("Left");
        
        if (!mat)
            return;
        
        mat.color = Color.Lerp(Color.red, Color.blue, VRInput.RightIndex());
    }
}
