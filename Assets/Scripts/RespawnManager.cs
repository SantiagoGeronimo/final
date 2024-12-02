using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2 spawnPosition;  

    

    public void SpawnPlayerIfNeeded()
    {
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}
