using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions 
{
    public static Vector3 DirectionTo(this Transform source, Transform target) {
        return source.position.DirectionTo(target.position);
    }

    public static float Distance(this Transform source, Transform target)
    {
        return Vector3.Distance(source.position, target.position);
    }

    public static float Distance(this Transform source, Vector3 target, Space? relativeTo) {
        if ((relativeTo ?? Space.World) == Space.World)
            return Vector3.Distance(source.position, target);
        else
            return Vector3.Distance(source.localPosition, target);
    }
    
    public static Transform FindChildRecursive(this Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                //            Debug.Log("Found child! His name is: " + child.name);
                return child;
            } else
            {
                Transform result = FindChildRecursive(child, name);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return null;
    }
    
}