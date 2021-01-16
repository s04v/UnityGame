using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealth
{
    [SerializeField] private StatValue health;
    public StatValue Health { get { return health; } }

    [SerializeField] private Stat armour;
    public Stat Armour { get { return armour; } }

    [SerializeField] private Stat invulnerabilityTime;
    public Stat InvulnerabilityTime { get { return invulnerabilityTime; } }

    [SerializeField] bool invulnerable;
    public bool Invulnerable { get { return invulnerable; } set { invulnerable = value; } }

    public event OnTakeHit onTakeHit;
    public event OnTakeDamage onTakeDamage;
    public event OnHeal onHeal;

    public void Heal()
    {
        onHeal.Invoke(0);
        health.Value += 0;
    }

    public void TakeHit()
    {
        if (invulnerable)
        { return; }
        onTakeHit?.Invoke();

        TakeDamage();
    }

    public void TakeDamage()
    {
        if (invulnerable)
        { return; }

        onTakeDamage?.Invoke(0);

        int damage = (0 - (int)armour.ResultValue);

        if (damage <= 0)
        { damage = 1; }

        health.Value -= damage;

        if (health.Value <= 0)
        { }
    }

    public IEnumerator Invulnerability()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime.ResultValue);
        invulnerable = false;
    }
}
