using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ListExtentions 
{

    public static void SetEachActive(this List<GameObject> list, bool active) {
        for (int i = 0; i < list.Count; i++) {
            list[i].SetActive(active);
        }
    }
    
    public static bool AddOneOf<T>(this List<T> list, T newObj)
    {
        foreach (var obj in list)
        {
            if (newObj.GetType().Equals(obj))
            {
                //failed, already contains an object of that type
                return false;
            }
        }
        
        list.Add(newObj);
        return true;

    }

    public static Transform Closest(this List<Transform> transforms, Transform relativeTo) {
        
        if (transforms.Count > 0) {
            return transforms.Aggregate((i1, i2) =>
                relativeTo.Distance(i1) < relativeTo.Distance(i2) ? i1 : i2);
        }
        
        return null;
            
    }

    
    //return first object of type target
    public static T GetTypeOf<T>(this IEnumerable<T> list, T target)
    {   
        return list.FirstOrDefault(obj => target.GetType().Equals(obj));
    }

    public static T Random<T>(this List<T> list) {

        int index = UnityEngine.Random.Range(0, list.Count() - 1);
        return list[index];

    }

    public static T RandomRange<T>(this List<T> list, int min, int max) {
        int index = UnityEngine.Random.Range(min, max);
        return list[index];
    }

    public static void AddUniqueVector(this List<Vector4> points, Vector3 newPoint, float tolerance) {
        bool unique = true;
        foreach (Vector4 point in points) {
            if (Vector4.Distance(point, newPoint) < tolerance) {
                unique = false;
            }
        }
        
        if (unique)
            points.Add(newPoint);
        
    }
    
}