using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private float timeBetweenSpawns = 2f;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    float spawnRateChange = .02f;
    

    private void Start() {
        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn() {

        while (true) {

            timeBetweenSpawns -= spawnRateChange;
            
            Spawn();
            yield return new WaitForSeconds(timeBetweenSpawns);
            
            
        }
        
    }

    private void Spawn() {
        Vector3 spawnPos = Random.insideUnitSphere * 15;
        spawnPos.y = Mathf.Clamp(spawnPos.y,5f, 15f);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
    
}
