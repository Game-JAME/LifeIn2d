using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Vector3[] coinPositions = {new Vector3(-73.3708725f,-1.53047371f,0.0f),new Vector3(-79.1999969f,27.8999996f,0.0f),new Vector3(-111.699997f,38.4000015f,0.0f),new Vector3(-111.699997f,22.5f,0.0f),new Vector3(-111.699997f,11.5f,0.0f),new Vector3(-111.699997f,-8.5f,0.0f),new Vector3(-111.699997f,-36.9000015f,0.0f),new Vector3(-82.8000031f,-36.9000015f,0.0f),new Vector3(-82.8000031f,-15.8999996f,0.0f),new Vector3(-82.8000031f,10.3999996f,0.0f),new Vector3(-82.8000031f,32f,0.0f)};
    [SerializeField] GameObject coinPrefab;
    
    void Start()
    {
        InvokeRepeating("SpawnCoin",1f,0.5f);
    }

    void SpawnCoin()
    {
        // select random position for coin to spawn and instantiate there
        Vector3 position = coinPositions[UnityEngine.Random.Range(0,coinPositions.Length)];
        Instantiate(coinPrefab,position,Quaternion.identity);
    }
}
