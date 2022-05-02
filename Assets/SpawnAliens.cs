using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        SpawnManager spawnManager = GetComponentInParent<SpawnManager>();

        spawnManager.SpawnAliens();
    }
}
