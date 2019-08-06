using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuaternionExtensions 
{
    public static Quaternion WithValues(this Quaternion original, float? x = null, float? y = null, float? z = null) {

        //double question mark shorthand for if (!= null), else other
        return Quaternion.Euler(x ?? original.x, y ?? original.y, z ?? original.z);

    }
}
