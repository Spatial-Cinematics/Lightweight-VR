using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtensions 
{
    public static bool IsBetween(this int value, int lower, int upper) {
        return (value >= lower && value <= upper);
    }
}
