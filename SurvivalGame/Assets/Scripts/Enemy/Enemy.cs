using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRange = 0.1f;

    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            if (timeBtwAttack <= 0)
            {
                OnEnemyAttack();
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Attack");
        if (other.CompareTag("Player"))
        {
            
            
        }
    }
   
    public void OnEnemyAttack()
    {
      
        player.GetComponent<PlayerResoursesManager>().currentHealth -= 10;
        Debug.Log(player.GetComponent<PlayerResoursesManager>().currentHealth);
    }
}