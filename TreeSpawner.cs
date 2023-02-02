using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public float spawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnRate, treePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}