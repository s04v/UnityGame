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
    public NewInventory inventory;
    [SerializeField] private Animator animator;

    [SerializeField] private Transform pfBullet;
    public Transform firePoint;

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
            inventory = GetComponent<NewInventory>();
        if (animator == null)
            animator = GetComponent<Animator>();

        updateHealth?.Invoke(currentHealth);
        //Popup.Create(transform.position, "300");
        /*PopupManager.CreatePopupText(transform.position, "200", Color.red);
        PopupManager.CreatePopupText(transform.position + new Vector3(2, 4, 0), "100", Color.blue);
        PopupManager.CreatePopupText(transform.position + new Vector3(-5, -3, 0), "100");*/
    }

    private void Update()
    {
        PlayerInput();
        if (Test)
        {
            updateHealth?.Invoke(currentHealth);
            PopupManager.CreatePopupText(transform.position, "200", Color.red);
            Test = false;
        }
        //Debug.Log(Input.mousePosition);
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        if (!isDead)
        {
            //Input.GEt
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
                inventory.Use(this);


                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 lookDir = mousePos - myRigidbody.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                Transform bullet = Instantiate(pfBullet, transform.position, Quaternion.identity);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

                bullet.GetComponent<Rigidbody2D>().AddForce(lookDir * 2f,ForceMode2D.Impulse);
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            { }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            { }

            change = Vector2.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            if (change.x != 0 || change.y != 0)
            {
                isMoving = true;
                animator.SetFloat("Horizontal", change.x);
                animator.SetFloat("Vertical", change.y);
                animator.SetFloat("Speed", change.magnitude);
            }
            else
            {
                isMoving = false;
                animator.SetFloat("Speed", 0f);
            }
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
