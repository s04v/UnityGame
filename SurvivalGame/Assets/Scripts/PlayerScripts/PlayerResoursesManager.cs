using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerResoursesManager : MonoBehaviour
{
    private int healthMax;
    private int currentHealth;

    private int armour;

    private int hungerMax;
    private int currentHunger;

    private int staminaMax;
    private int currentStamina;

    void Start()
    {
        
    }

    void Update()
    {
        
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
        int takenDamage = (int)(1 - (float)damage * (.7 * armour));
        if (currentHealth < takenDamage)
            currentHealth = 0;
        else
            currentHealth -= takenDamage;
    }



}
