using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        if (textMesh == null)
            textMesh = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        
    }

    public static Popup Create(Vector2 pos, string text)
    {
        Popup popup = null;
        return popup;
    }
}
