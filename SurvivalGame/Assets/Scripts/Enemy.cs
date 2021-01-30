using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public AIPath aiPath;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRange = 0.1f;

    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int health = 100;
  
    public bool slowed = false;
    public float sloweTime = 0;

    public SP2 spawner;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        aiPath = this.GetComponent<AIPath>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sloweTime > Time.time)
        { 
            aiPath.maxSpeed = 2.5f;
        }
        else
        {
            aiPath.maxSpeed = 5f;
        }

        timeBtwAttack -= Time.deltaTime;
        
       
       //Debug.Log("timeBtwAttack " + timeBtwAttack + " " + Time.deltaTime);


    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        /*rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            Debug.Log("moveCharacter");
            if (timeBtwAttack <= 0)
            {
                OnEnemyAttack();
                timeBtwAttack = startTimeBtwAttack;
            }
        }*/
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                Debug.Log("ATTACK");
                player.GetComponent<PlayerPrePreAlpha>().TakeDamage(10);
                Debug.Log("cur health " + player.GetComponent<PlayerPrePreAlpha>().currentHealth);
                timeBtwAttack = startTimeBtwAttack;
            }
        }
    }
   
    public void OnEnemyAttack()
    { }

    public void TakeDamage (int damage)
    {
        sloweTime = Time.time + 1.5f;
        health -= damage;
        Debug.Log("TakeDamage");

        if (health <= 0)
        {
             Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log("123441242");
        Bullet bullet = hitInfo.GetComponent<Bullet>();

        if (bullet != null)
        {
            TakeDamage(bullet.damage);
            bullet.Die();
            //Debug.Log(health);
        }
    }
    void Die ()
    {
        Destroy(gameObject);
        spawner.kill();
        //KillCounter kill_counter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
        // kill_counter.Kill();

        // Debug.Log("Kill enemy");

    }
}