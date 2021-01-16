using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnTakeHit();
public delegate void OnTakeDamage(int damageAmout);
public delegate void OnHeal(int healAmout);

public interface IHealth
{
    StatValue Health { get; }

    Stat Armour { get; }

    Stat InvulnerabilityTime { get; }
    bool Invulnerable { get; set; }



    event OnTakeHit onTakeHit;
    event OnTakeDamage onTakeDamage;
    event OnHeal onHeal;


    void TakeHit();
    void TakeDamage();
    void Heal();

    IEnumerator Invulnerability();
}
