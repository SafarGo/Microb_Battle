using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int HP = 0;

    private void Update()
    {
        if (HP == 100)
        {
            GameManager.count_of_ready_walls++;
        }
    }
}
