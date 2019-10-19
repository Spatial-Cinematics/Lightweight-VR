using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(SphereCollider))]
public class Grabber : MonoBehaviour {

    [HideInInspector]
    public Transform grabbedTransform;
    public Handedness handedness;
    public GameObject deleteThisPrefab;
    public Material glowMaterial;
    
    [SerializeField, HideInInspector]
    private List<Transform> inRange = new List<Transform>();
    [SerializeField]
    private float inputThreshold = .5f; // pulled half way
    [SerializeField]
    private float throwPower = 1;
    
    private float indexInput, handInput;
    private int velocityInputRange = 5;
    private Dictionary<GameObject, Material> materials = new Dictionary<GameObject, Material>();
    private Vector3 currentPos, lastPos, velocity;
    private Queue<Vector3> velocityInputs = new Queue<Vector3>(); //calculate to handle throwing
    

    private void Update() {

        UpdateVelocity();
        print(velocityInputs);
        
        if (VRInput.GetDown(GenericVRButton.Hand, handedness)) {
            Grab();
        } else if (VRInput.GetUp(GenericVRButton.Hand, handedness)) {
            Drop();
        }
        
    }


    private void UseGrabbed() {
        grabbedTransform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    private void Grab() {
        
            //closest grabbable transform out of in range grabbable transforms
            Transform closest = null;
            
            //find closest
            if (inRange.Count > 0) {
                closest = inRange.Aggregate((i1, i2) =>
                    transform.Distance(i1) < transform.Distance(i2) ? i1 : i2);
            }

            if (closest) { // an item is in range - pick it up
                grabbedTransform = closest;
                closest.GetComponent<Grabbable>().OnGrab(this);
                //REMOVE FROM IN RANGE TO STOP HIGHLIGHT
            }
        
    }

    private void UpdateVelocity() {

        currentPos = transform.position;
        velocityInputs.Enqueue(currentPos - lastPos);
        if (velocityInputs.Count > velocityInputRange)
            velocityInputs.Dequeue();

        Vector3 sum = Vector3.zero;

        foreach (Vector3 vel in velocityInputs) {
            sum += vel;
        }

        velocity = sum / velocityInputs.Count;
        
        lastPos = currentPos;

    }

    public void Drop() {
        
        if (!grabbedTransform)
            return;

        Grabbable g = grabbedTransform.GetComponent<Grabbable>();
        g.rb.velocity = velocity * throwPower;
        g.OnDrop(this);
        
        
    }
    
    #region Reference Grabbable Items

    //create list of grabbable transforms in range of hand
    private void OnTriggerEnter(Collider other) {

        Grabbable grabbable = other.GetComponent<Grabbable>();
        
        if (!grabbable)
            return;
        
        inRange.Add(grabbable.transform);
        HighlightGrabbable(other.gameObject, true);
    }

    private void OnTriggerExit(Collider other) {
        
        Grabbable grabbable = other.GetComponent<Grabbable>();
        
        if (!grabbable)
            return;

        inRange.Remove(grabbable.transform);
        HighlightGrabbable(other.gameObject, false);

    }

    private void HighlightGrabbable(GameObject obj, bool highlight) {

        MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
        if (!mesh)
            mesh = obj.GetComponentInChildren<MeshRenderer>();

        if (highlight) {
            materials.Add(obj, mesh.material); //save material for restoring
            mesh.material = glowMaterial;
        }
        else {

            if (!materials[obj]) {
                Debug.LogError("Object mesh: " + obj + ", material not save in dictionary");
                return;
            }
            
            mesh.material = materials[obj];
            materials.Remove(obj);
        }

    }

    #endregion
    
    
}