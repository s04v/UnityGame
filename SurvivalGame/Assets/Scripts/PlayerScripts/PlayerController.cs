using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveLimiter = 0.7f;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;
    private bool isDead = false;

   

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!isDead)
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            if (change.x != 0 && change.y != 0)
            {
                change.x *= moveLimiter;
                change.y *= moveLimiter;
            }

        }

        else
        {
            myRigidbody2D.velocity = Vector2.zero;
        }

        //Debug.Log(change);
    }


    public void setIsDead(bool isDead)
    {
        Debug.Log("Dead");
        this.isDead = isDead;
    }

    public bool PlayerIsDead()
    {
        return isDead;
    }


    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        myRigidbody2D.velocity = new Vector2(change.x * speed, change.y * speed);
    }





    enum PlayerDirection
    {
        Left,
        Right,
        Top,
        Down
    }
}
