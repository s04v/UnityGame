using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int kills = 0;
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void Kill()
    {
        kills++;
    }

    public int GetKills()
    {
        return kills;
    }

}
