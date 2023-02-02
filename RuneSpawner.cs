using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSpawner : MonoBehaviour
{
    public GameObject[] runePrefabs;
    public float spawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRune(spawnRate, runePrefabs[0]));
    }


    private IEnumerator spawnRune(float interval, GameObject rune)
    {
        yield return new WaitForSeconds(interval);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-9, 10), Random.Range(-5, 6), 1);
        Instantiate(runePrefabs[Random.Range(0, 5)], randomSpawnPosition, Quaternion.identity);
        StartCoroutine(spawnRune(interval, rune));
    }
}
