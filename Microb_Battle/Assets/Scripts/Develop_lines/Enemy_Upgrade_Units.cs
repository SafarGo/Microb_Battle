using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Upgrade_Units : MonoBehaviour
{
    public Button but1;
    public Button but2;
    public Button but3;
    public Button but4;

    public void Upgr1()
    {
        GameManager.isUpgr1 = true;
        but1.interactable = false;
    }

    public void Upgr2()
    {
        GameManager.isUpgr2 = true;
        but2.interactable = false;
    }

    public void Upgr3()
    {
        GameManager.isUpgr3 = true;
        but3.interactable = false;
    }

    public void Upgr4()
    {
        GameManager.isUpgr4 = true;
        but4.interactable = false;
    }
}
