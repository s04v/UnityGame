using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed;
    public float moveLimiter = 0.7f;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") ;
        change.y = Input.GetAxisRaw("Vertical") ;
        Debug.Log(change);
    }


    void FixedUpdate()
    {
        if (change.x != 0 && change.y != 0) 
        {
            change.x *= moveLimiter;
            change.y *= moveLimiter;
        }
        myRigidbody2D.velocity = new Vector2(change.x * speed, change.y * speed);
        //myRigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
