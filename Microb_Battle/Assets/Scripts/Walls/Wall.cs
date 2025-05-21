using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int hp = 0;

    private void Update()
    {
        if (hp == 100)
        {
            GameManager.count_of_ready_walls++;
        }
    }
}
