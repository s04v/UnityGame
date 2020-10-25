using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 500;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    public bool dir = true;
    public bool _moveRight = true;
    public float _maxRange = 5;
    private float range = 0;
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
        _maxRange *= 100;
    }

 
    // Start is called before the first frame update
    public void Update()
    {
        float _s = _startPos;
        float _e = _endPos;

        float ex = enemyRigidBody2D.position.x;
        float ey = enemyRigidBody2D.position.y;
        float d = 0.005f;

        // true = right direction
        // false = left direction
        if (dir)
        {
            enemyRigidBody2D.MovePosition(new Vector2(ex + EnemySpeed * d, ey));
            range++;
            if (range > _maxRange)
            {
                dir = false;
                range = 0;
            }
        } else
        {
            enemyRigidBody2D.MovePosition(new Vector2(ex - EnemySpeed * d, ey));
            range++;
            if (range > _maxRange) {
                dir = true;
                range = 0;
            }
        }
      

        /*if (_moveRight)
        {
            enemyRigidBody2D.AddForce(Vector2.right * EnemySpeed * d);
            if (!_isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            
            enemyRigidBody2D.AddForce(-Vector2.right * EnemySpeed * d);
           if (_isFacingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;*/
        
    }

    public void Flip() {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
   }

  
}
