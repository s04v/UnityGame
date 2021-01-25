using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : Singleton<GameAssets>
{
    public GameObject TextPopupPrefab;

    protected override void Awake()
    {
        base.Awake();
    }
}
