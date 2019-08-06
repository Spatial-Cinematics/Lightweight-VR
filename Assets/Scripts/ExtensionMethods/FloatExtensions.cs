using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    private static bool CloserTo(this float value, float to, float than) {

        return Mathf.Abs(value) + Mathf.Abs(to) < Mathf.Abs(value) + Mathf.Abs(than);

    }
}
