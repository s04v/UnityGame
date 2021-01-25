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
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if(boxCollider2D == null)
            boxCollider2D = GetComponent<BoxCollider2D>();
        if(pickableObject == null)
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
        Debug.Log("Triggered");
        if (!isPickable || !collider.CompareTag("Player"))
            return;
        Debug.Log("Test");
        PlayerPrePreAlpha player = collider.GetComponent<PlayerPrePreAlpha>();
        if (player != null)
        {
            pickableObject.OnPick(player);
        }
    }
}

