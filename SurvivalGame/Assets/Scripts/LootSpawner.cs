using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public GameObject item;
    public List<Transform> points;

    public float spawnRate = 2f;
    public float nextSpawn = 0.0f;

    public bool[] isFreePoint;

    void Start()
    {
        isFreePoint = new bool[5];
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        points.AddRange(allChildren);
    }

    void Update()
    {

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int i = Random.Range(0, 3);
            Vector2 position = points[i].position;
            Instantiate(item, position, Quaternion.identity);
            Debug.Log("item spawn");
        }
    }
}
