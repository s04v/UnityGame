using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 wheteToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    int StartEnemyNumber = 2;

    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            for (int i = 0; i < 2; i++)
            {
                randX = Random.Range(-1f, 1f);
                wheteToSpawn = new Vector2(transform.position.x, transform.position.y);
                Instantiate(enemy, wheteToSpawn, Quaternion.identity);
               // StartEnemyNumber += 2;
             }
        }

    }
}
