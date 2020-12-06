using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerResoursesManager : MonoBehaviour, IEntityResourseSystem
{
    public int healthMax;
    public int currentHealth;

    private int armour;

    private int hungerMax;
    private int currentHunger;

    private int staminaMax;
    private int currentStamina;

    public PlayerController PlayerControll;

    public int Health { get { return currentHealth; }}
    //public bool IsAlive { get =}

    void Start()
    {
        PlayerControll = GetComponent<PlayerController>();
        currentHealth = healthMax;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerControll.setIsDead(true);
            
        }

        //Debug.Log(currentHealth);

    }

    // Current heath methods 
    public void Heal(int healAmout)
    {
        if ((healAmout + currentHealth) > healthMax)
            currentHealth = healthMax;
        else
            currentHealth += healAmout;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int health)
    {
        this.currentHealth = health;
    }

    //Max health methods
    public int GetHealthMax()
    {
        return healthMax;
    }

    public void SetHealthMax(int healthMax)
    {
        this.healthMax = healthMax;
    }

    // Current hunger methods
    public void Eat(int eatAmout)
    {
        if (currentHunger + eatAmout > hungerMax)
            currentHunger = hungerMax;
        else
            currentHunger += eatAmout;
    }

    public int GetCurrentHunger()
    {
        return currentHunger;
    }

    public void SetCurrentHunger(int hunger)
    {
        this.currentHunger = hunger;
    }


    //Max hunger methods
    public int GetHungerhMax()
    {
        return hungerMax;
    }

    public void SethungerhMax(int hungerhMax)
    {
        this.hungerMax = hungerhMax;
    }


    // Damage methods
    public void TakeDamage(int damage)
    {
        int takenDamage = (int)(1 +(float)damage * (.7 / armour));
        currentHealth = Mathf.Clamp(currentHealth - takenDamage, 0, healthMax);
        if (currentHealth == 0)
        {
            //Смерть
        }
    }


}
