using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;
    // Start is called before the first frame update
    void Start()
    {
        Transform bulletTransform = Instantiate(pfBullet,transform.position, Quaternion.identity);

        Vector3 shootDir = new Vector3(1, 0, 0).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(shootDir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
