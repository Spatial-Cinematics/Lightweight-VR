using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SnapOnGrab))]
public class SnapEditor : Editor
{
    public override void OnInspectorGUI() {

        SnapOnGrab snap = (SnapOnGrab) target;
        
        if (GUILayout.Button("Bake Snap Orientation")) {
            Bake(snap);
        }

    }

    private void Bake(SnapOnGrab snap) {

        //refrence to grabbed objects transform
        Transform transform = snap.transform;
        //find hands
        Grabber[] hands = FindObjectsOfType<Grabber>();
        //reference closest hand - this will be the reference
        Transform t1 = hands[0].transform;
        Transform t2 = hands[1].transform;
        Transform closestHand = t1.Distance(transform) < t2.Distance(transform) ? t1 : t2;

        Transform tmpParent = transform.parent;
        transform.parent = closestHand;
        snap.snapPosition = transform.localPosition;
        snap.snapOrientation = transform.rotation;
        transform.parent = tmpParent;

    }
    
}
