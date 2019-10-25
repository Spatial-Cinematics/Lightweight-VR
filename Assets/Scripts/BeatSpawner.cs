using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour {
    [SerializeField] private Material blue, red;
    [SerializeField] 
    private GameObject beat;
    [SerializeField]
    private float spawnWait = 2;

    private float spawnZ = 10;
    private float spawnX = .5f;
    private float timeOut = 10f;
    
    void Start() {
        StartCoroutine(LoopSpawn());
    }

    IEnumerator LoopSpawn() {

        while (true) {
            
            yield return new WaitForSeconds(spawnWait);
            
            Spawn();
            
        }
        
    }

    private void Spawn() {

        bool left = Random.value > .5f;
        Vector3 spawnPos = new Vector3(left ? -spawnX : spawnX, 1, spawnZ);
        Beat beatInstance = Instantiate(beat, spawnPos, Quaternion.identity).GetComponent<Beat>();
        Destroy(beatInstance.gameObject, timeOut);

    }

}
