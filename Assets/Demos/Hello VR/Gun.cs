using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Gun : MonoBehaviour {
    
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletLiftime = 2;

    public void Shoot() {
        
        Destroy(Instantiate(bulletPrefab, muzzle.position, muzzle.rotation), bulletLiftime);
        
    }
    
    
}
