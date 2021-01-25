using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    Sprite Icon { get; set; }

    void OnPick(PlayerPrePreAlpha player);
}