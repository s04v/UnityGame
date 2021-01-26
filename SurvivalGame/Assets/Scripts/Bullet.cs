using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 shootDir;
    public Rigidbody2D rb;
    public int damage = 30;
    private float GetAngelFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 30;

        return n;
    }

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
       // transform.eulerAngles = new Vector3(0, 0, this.GetAngelFromVectorFloat(shootDir));
        //Destroy(gameObject, 5f);
    }
    void Start()
    {
        //rb.velocity = transform.right * speed;
    }

    void Update()
    {
        //float moveSpeed = f;
        transform.position += shootDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider hitInfo)
    {
        Debug.Log("OnTrigger");
       /* Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);*/
    }
}
