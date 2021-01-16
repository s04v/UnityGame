using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private bool isPickable;

    [SerializeField] public IPickable pickableObject;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        pickableObject = GetComponent<IPickable>();
        UpdateSprite();
    }

    void Update()
    {
        
    }

    public void UpdateSprite()
    {
        if (pickableObject == null)
        {
            spriteRenderer.sprite = DataBase.Instance?.GetItemByID(-1).icon;
        }
        spriteRenderer.sprite = pickableObject.Icon;
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (!isPickable || !collider.CompareTag("Player"))
            return;
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            pickableObject.OnPick(player);
        }
    }
}
