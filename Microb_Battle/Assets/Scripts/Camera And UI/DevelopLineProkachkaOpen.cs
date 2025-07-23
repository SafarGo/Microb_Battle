using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopLineProkachkaOpen : MonoBehaviour
{
    bool isActivate = false;
    [SerializeField] GameObject developLine;
    private void Awake()
    {
        developLine.SetActive(isActivate);
    }
    public void Act()
    {
        isActivate = !isActivate;
        developLine.SetActive(isActivate);
    }
}
