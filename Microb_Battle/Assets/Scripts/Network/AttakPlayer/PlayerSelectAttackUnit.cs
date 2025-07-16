using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectAttackUnit : MonoBehaviour
{
    private PlayerNetEnemiesSpawnController PNSC;
    private void Start()
    {
        PNSC = FindObjectOfType<PlayerNetEnemiesSpawnController>();
    }
    public void SelectAtackUn(int ind)
    {
        PNSC.SelectAtackUnit(ind);
    }
}
