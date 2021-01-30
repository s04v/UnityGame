using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SP2 : MonoBehaviour
{
    public GameObject enemy;
    public Transform target;

    public List<Transform> list;

    public float nextSpawn = 0.0f;
    public float spawnRate = 2f;
    public int curentEnemy = 0;

    public int kills = 0;

    public int level = 0;
    void Start()
    {
       
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        list.AddRange(allChildren);
    }


    void Update()
    {
        level = kills / 5;

        if (Time.time > nextSpawn && curentEnemy < 5 + level)
        {
            nextSpawn = Time.time + spawnRate;
            int i = Random.Range(0, 3);
            Vector2 position = list[i].position;

            GameObject enemyObject =  Instantiate(enemy, position, Quaternion.identity);
            Enemy e = enemyObject.GetComponent<Enemy>();
            AIDestinationSetter ai = enemyObject.GetComponent<AIDestinationSetter>();
            ai.target = target;
            e.spawner = this;
            e.health = 100 + level * 10;

            curentEnemy++;
            Debug.Log("current enemy = " + curentEnemy);
        }
    }
    public void kill()
    {
        curentEnemy--;
        kills++;
    }
}
