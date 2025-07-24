using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtakDevelopTree : MonoBehaviour
{
    public void AntyKetogenes1(int price)
    {
        GameManager.AttackHPBouns = 1.05f;
        GameManager.Count_of_belok -= price;
        GameObject.Find("Anti_ket_1").GetComponent<Button>().interactable = false;
    }
    public void AntyKetogenes2( int price)
    {
       GameManager.attakUnitsSpeedBonus = 1.2f;
        GameManager.Count_of_belok -= price;
        GameObject.Find("Anti_ket_2").GetComponent<Button>().interactable = false;
    }
    public  void BacterUp1( int price)
    {
        GameManager.Klostridiy_attack_bonus = 1.1f;
        GameManager.Count_of_belok -= price;
        GameObject.Find("Upgrade1").GetComponent<Button>().interactable = false;
    }

    public  void BacterUp2( int price)
    {
        GameManager.streptoFogLifetimeBonus = 1.15f;
        GameManager.Count_of_belok -= price;
        GameObject.Find("Upgrade2").GetComponent<Button>().interactable = false;
    }

    public  void BacterUp3( int price)
    {
        GameManager.isUpgr3 = true;
        GameManager.Count_of_belok -= price;
        GameObject.Find("Upgrade3").GetComponent<Button>().interactable = false;
    }

    public  void BacterUp4(int price)
    {
        GameManager.isUpgr4 = true;
        GameManager.Count_of_belok -= price;
        GameObject.Find("Upgrade4").GetComponent<Button>().interactable = false;
    }
}

