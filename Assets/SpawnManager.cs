using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject aliensPrefab;
    public Transform spawnPosition;

    public float delay;
    public bool canSpawn = true;
    public float spawnOffset;
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    public IEnumerator SpawnAsteroid()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(delay);
            Vector2 newPosition = new Vector2(spawnPosition.position.x + Random.Range(-spawnOffset, spawnOffset), spawnPosition.position.y);
            Instantiate(asteroidPrefab, newPosition, Quaternion.identity);
        }
    }

    public void SpawnAliens()
    {
        Instantiate(aliensPrefab, spawnPosition.position, Quaternion.identity);
    }
}
