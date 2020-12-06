using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public Inventory inventory;
    public Inventory Inventory { get { return inventory; } }

    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController { get { return PlayerController; } }

    public IEntityResourseSystem resourseSystem { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    void Start()
    {
        inventory = GetComponent<Inventory>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}