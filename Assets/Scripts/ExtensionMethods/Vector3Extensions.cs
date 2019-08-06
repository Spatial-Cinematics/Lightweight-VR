using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions 
{

    //question marks indicate a nullable type
    public static Vector3 WithValues(this Vector3 original, float? x = null, float? y = null, float? z = null) {

        //double question mark shorthand for if (!= null), else other
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);

    }

    public static Vector3 DirectionTo(this Vector3 source, Vector3 target) {
        //calculate distance and normalize
        return Vector3.Normalize(target - source);
    }

    public static float Distance(this Vector3 source, Vector3 target) {
        return Vector3.Distance(source, target);
    }

    public static float MaxValue(this Vector3 source) {

        float max = source.x;
        if (source.y > max)
            max = source.y;
        if (source.z > max)
            max = source.z;

        return max;

    }
    
    public static float MinValue(this Vector3 source) {

        float min = source.x;
        if (source.y < min)
            min = source.y;
        if (source.z < min)
            min = source.z;

        return min;

    }

    public static Vector3 Random(this Vector3 source, 
        float? minX = null, float? maxX = null,
        float? minY = null, float? maxY = null,
        float? minZ = null, float? maxZ = null) {

        float x = UnityEngine.Random.Range(minX ?? 0, maxX ?? 1);
        float y = UnityEngine.Random.Range(minY ?? 0, maxY ?? 1);
        float z = UnityEngine.Random.Range(minZ ?? 0, maxZ ?? 1);
        
        
        return new Vector3(x,y,z);
        
    }

    public static Vector3 GetPointParametrically(this List<Vector3> points, int vertex, float t) {

        Vector3 
            p0 = points[vertex - 1], 
            p1 = points[vertex], 
            p2 = points[vertex + 1];
        
        //see https://catlikecoding.com/unity/tutorials/curves-and-splines/ for explanation
        return Vector3.Lerp(Vector3.Lerp(p0,p1,t), Vector3.Lerp(p1,p2,t), t);

    }

    
}