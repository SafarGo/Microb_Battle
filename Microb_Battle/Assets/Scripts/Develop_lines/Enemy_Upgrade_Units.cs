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

    public void Upgr1(int price)
    {
        but1.interactable = false;
        GameManager.Count_of_belok -= price; 
    }

    public void Upgr2(int price)
    {
        but2.interactable = false;
        GameManager.Count_of_belok -= price;
    }

    public void Upgr3(int price)
    {
        GameManager.isUpgr3 = true;
        but3.interactable = false;
        GameManager.Count_of_belok -= price;
    }

    public void Upgr4(int price)
    {
        GameManager.isUpgr4 = true;
        but4.interactable = false;
        GameManager.Count_of_belok -= price;
    }
}
