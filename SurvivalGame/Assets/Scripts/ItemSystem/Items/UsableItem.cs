using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealItem", menuName = "Assets/Items/HealItem")]
public class UsableItem : Item
{
    public int healAmout = 50;
    public BaseItemBehavior behavior;

    public void OnUse(PlayerPrePreAlpha player)
    {
        player.Heal(50);
    }
}
