using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ManusLibrary;

public class AliensManager : Singleton<AliensManager>
{
    public List<Alien> aliens;

    public bool canMove = true;
    public float speed = 10f;
    public float fallingSpeed = 2f;
    public float multiplier = 1f;

    public Transform spawnPoint;
    public Transform alienParent;
    public List<GameObject> alienPrefabs;

    public float spawnInterval = 1f;
    public float spawnOffset = 0.15f;
    public int spawnAmount = 8;
    public float time;

    public int[] timeStamps = new int[4];
    public int currentStamp = 0;

    IEnumerator Start()
    {
        aliens = FindObjectsOfType<Alien>().ToList();

        StartCoroutine(SpawnWave());
        StartCoroutine(StageChanger());
        yield return null;
    }

    public void ToggleDirection()
    {
        multiplier = multiplier > 0 ? -1 : 1;
    }

    public IEnumerator SpawnWave()
    {
        while(canMove)
        {
            yield return new WaitForSeconds(spawnInterval);

            int spawnCount = Random.Range(0, spawnAmount);
            float spawnRandomOffset = Random.Range(spawnOffset, spawnOffset * 1.2f);

            for(int i = 0; i < spawnCount; i++)
            {
                Vector2 newPosition = new Vector2(spawnPoint.position.x + spawnRandomOffset * i, spawnPoint.position.y);
                Instantiate(alienPrefabs.RandomElement(), newPosition, Quaternion.identity, alienParent);
            }
        }
    }

    public IEnumerator StageChanger()
    {
        while(canMove)
        {
            if(currentStamp == 5)
            {
                canMove = false;
                yield return null;
            }

            time += Time.deltaTime;
            if(time > timeStamps[currentStamp])
            {
                currentStamp++;
                ChangedStage();
            }

            yield return null;
        }
    }

    private void ChangedStage()
    {
        spawnAmount++;
        speed *= 1.1f;
        spawnInterval -= 0.5f;
    }
}
