using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrePreAlpha : MonoBehaviour
{
    public bool isDead;
    public bool isMoving;
    [Space]
    public bool Test;

    public float moveLimiter = 0.7f;
    
    private Vector2 change;


    [Header("Stats:")]
    public float speed = 3;
    public int maxHealth = 100;
    public int currentHealth = 100;

    [Header("Other:")]
    [SerializeField] private Rigidbody2D myRigidbody;
    public Inventory inventory;


    //Events
    public delegate void UpdateHealth(int newValue);
    public event UpdateHealth updateHealth;

    public delegate void OnTakeDamage(int amout);
    public event OnTakeDamage onTakeDamage;

    public delegate void OnHeal(int amout);
    public event OnHeal onHeal;

    public delegate void OnDead();
    public event OnDead onDead;



    private void Start()
    {
        if(myRigidbody == null)
            myRigidbody = GetComponent<Rigidbody2D>();
        if (inventory == null)
            inventory = GetComponent<Inventory>();

        updateHealth?.Invoke(currentHealth);
    }

    private void Update()
    {
        PlayerInput();
        if (Test)
        {
            updateHealth?.Invoke(currentHealth);
            Test = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        if (!isDead)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Use
            }

            change = Vector2.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            if (change.x != 0 || change.y != 0)
                isMoving = true;
            else
                isMoving = false;


            
        }
    }

    public void Move() 
    {
        if (change.x != 0 && change.y != 0)
        {
            change *= moveLimiter;
        }
        myRigidbody.velocity = change * speed;
    }

    public void TakeDamage(int amout)
    {
        currentHealth -= amout;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();
        }

        onTakeDamage?.Invoke(amout);
        updateHealth?.Invoke(currentHealth);
    }

    public void Heal(int amout)
    {
        currentHealth += amout;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        onHeal?.Invoke(amout);
        updateHealth?.Invoke(currentHealth);
    }

    public void Dead()
    {
        change = Vector2.zero;
        isMoving = false;

        onDead?.Invoke();
    }

}
