using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP_Canvas_Controller : MonoBehaviour
{

    private void Update()
    {
        gameObject.transform.LookAt(GameObject.Find("Main Camera").transform);
    }
}
