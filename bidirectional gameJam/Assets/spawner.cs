using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;
    float randomNum;
         

    [SerializeField] GameObject ballPrefab;

    private void Start()
    {
        randomNum = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("createBall", randomNum);
    }

    void createBall() 
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        randomNum = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("createBall", randomNum);
    }
}
