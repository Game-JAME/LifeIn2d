using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] Vector3[] coinPositions = {new Vector3(-73.3708725f,-1.53047371f,0.0f),new Vector3(-79.1999969f,27.8999996f,0.0f),new Vector3(-83.0f,-12.6000004f,0.0f)};
    [SerializeField] GameObject coinPrefab;
    
    void Start()
    {
        InvokeRepeating("SpawnCoin",1f,1f);
    }

    void SpawnCoin()
    {
        // select random position for coin to spawn and instantiate there
        Vector3 position = coinPositions[UnityEngine.Random.Range(0,coinPositions.Length)];
        Instantiate(coinPrefab,position,Quaternion.identity);
    }
}
