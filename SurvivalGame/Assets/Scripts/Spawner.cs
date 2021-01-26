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
    KillCounter kill_counter;
    void Start()
    {
        kill_counter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
    }

    void Update()
    {
        Debug.Log(kill_counter.GetKills());
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            WaveSpawn(2);
        }

    }
    
    public void WaveSpawn(int enemy_number)
    {
        for (int i = 0; i < enemy_number; i++)
        {
            randX = Random.Range(-1f, 1f);
            wheteToSpawn = new Vector2(transform.position.x, transform.position.y);
            Instantiate(enemy, wheteToSpawn, Quaternion.identity);
            // StartEnemyNumber += 2;
        }
    }
}
