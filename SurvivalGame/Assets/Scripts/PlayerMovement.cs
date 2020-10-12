using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        Debug.Log(change);
        if (change != Vector3.zero)
        {
            Movement();
        }
    }


    void Movement()
    {
        myRigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
