using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItemBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnUse(PlayerPrePreAlpha player, Item item)
    {
        player.Heal(50);
    }
}
