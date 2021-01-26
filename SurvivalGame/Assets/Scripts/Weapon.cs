using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("click");

            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("SHOOT");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
