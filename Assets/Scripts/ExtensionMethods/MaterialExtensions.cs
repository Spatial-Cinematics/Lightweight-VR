using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialExtensions 
{

    public static void StepFloat(this Material mat, string key, float target, float rate) {

        float current = mat.GetFloat(key);
        float step = Mathf.MoveTowards(current, target, Time.deltaTime * rate);
        mat.SetFloat(key, step);

    }
    
    public static void LerpFloat(this Material mat, string key, float target, float rate) {

        float current = mat.GetFloat(key);
        float step = Mathf.Lerp(current, target, Time.deltaTime * rate);
        mat.SetFloat(key, step);

    }
    
}
