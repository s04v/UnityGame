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

    int waveNumber = 1;
    int StartEnemyNumber = 2;
    KillCounter kill_counter;
    void Start()
    {
        kill_counter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
        //WaveSpawn(StartEnemyNumber + waveNumber);
        waveNumber++;
    }

    void Update()
    {
        //int kills = kill_counter.GetKills();
       // Debug.Log(kills);

        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            WaveSpawn(3);
            //waveNumber++;
            //kill_counter.ResetKills();
        }
    }
    
    public void WaveSpawn(int enemy_number)
    {
        for (int i = 0; i < enemy_number; i++)
        {
            randX = Random.Range(-5f, 5f);
            wheteToSpawn = new Vector2(transform.position.x, transform.position.y);
            Instantiate(enemy, wheteToSpawn, Quaternion.identity);
            // StartEnemyNumber += 2;
        }
    }
}
