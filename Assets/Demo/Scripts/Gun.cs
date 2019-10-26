using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Gun : MonoBehaviour {
    
    public GameObject bullet;

    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private float lifeTimeInSeconds = 2f;


    public void Shoot() {
        //instantiate the bullet at muzzle and destroy after lifetime
        Destroy(Instantiate(bullet, muzzle.position, muzzle.rotation), lifeTimeInSeconds);
        
    }
    
    
}
