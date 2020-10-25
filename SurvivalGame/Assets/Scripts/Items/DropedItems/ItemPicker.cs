using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Test");
        //Pick(Item.TargetInventoryName);
    }
}
