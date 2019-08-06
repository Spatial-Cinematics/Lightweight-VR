using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions 
{
    public static Vector3 Vector(this string data) {
        
        string[] splits = data.Split(',');
        Vector3 v = new Vector3();
        
        for (int i = 0; i < splits.Length; i++) {
            v[i] = float.Parse(splits[i]);
        }

        return v;
        
    }
}
