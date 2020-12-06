using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour, IPickable
{
    [SerializeField] private InventorySlot item;

    public delegate void UpdateItem();
    public event UpdateItem update;
    public InventorySlot Item
    {
        get {return item;}
        set
        {
            item = value;
            Debug.Log("Ok");
            update?.Invoke();
        }
    }


    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private bool isPickable;


    public bool IsPickable { 
        get
        { return isPickable; }
        private set
        {
            isPickable = value;
            if (isPickable == true)
            {
                boxCollider2D.enabled = true;
            }
            else
            {
                boxCollider2D.enabled = false;
            }
        } 
    }

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }


    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (!IsPickable || !collider.CompareTag("Player"))
        {
            return;
        }
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            OnPick(player);
        }
    }

    public void OnPick(Player player)
    {
        InventoryEvent pickEvent = new InventoryEvent(InventoryEventTypes.PickItem, Item, 0);
        pickEvent.Trigger();
        if (item.Count == 0)
            Destroy(gameObject);
    }

    public IEnumerator PickableDelay()//Задержка перед тем как предмет можно подобрать (Не совсем правильно работает если во время включения колайдера и игрок в нем то он не работает)
    {
        isPickable = false;
        yield return new WaitForSeconds(0.3F);
        isPickable = true;
    }

    public IEnumerator SetVelocity(float time, Vector2 startVelocity)
    {
        
        rigidbody2D.velocity = startVelocity;
        Debug.Log(rigidbody2D.velocity);
        Vector2 velocity = Vector2.zero;
        Vector2.SmoothDamp(startVelocity, Vector2.zero, ref velocity, time);
        while (rigidbody2D.velocity != Vector2.zero)
        {
            rigidbody2D.velocity = velocity;//Vector2.Lerp(startVelocity, Vector2.zero, time / );
            Debug.Log(rigidbody2D.velocity);
            yield return null;
        }
        yield return null;
    }
}
