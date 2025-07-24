using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Upgrade_Units : MonoBehaviour
{
    public  float PriceOfAnti1;
    public  float PriceOfAnti2;
    public  float PriceOfUpgr1;
    public  float PriceOfUpgr2;
    public  float PriceOfUpgr3;
    public  float PriceOfUpgr4;
    public List<Button> buttons = new List<Button>();
    public static float attakUnitsSpeedBonus = 1f;
    public static float attakUnitsHPBonus = 1f;
    public static float streptoFogLifetimeBonus = 1f;
    public static float klostrydyy_attack_bonus = 1f;
    public static float Bacillus_attack_in_fog_bonus = 1f;
    public static float AttackUnits_speedBonus = 1f;
    public static float AttackUnits_HPBonus = 0f;
    public GameObject CreateTuberStick_button;
    public static bool isUp1;
    public static bool isUp2;
    public static bool isUp3;
    public static bool isUp4;
    public static bool isAnti1;
    public static bool isAnti2;
    public void ChandgeKlostAttackBunus(float bonus)
    {
        if (GameManager.Count_of_belok >= PriceOfUpgr1 && !isUp1)
        {
            klostrydyy_attack_bonus += bonus;
            GameManager.Count_of_belok -= PriceOfUpgr1;
            buttons[0].GetComponent<Button>().interactable = false;
            isUp1 = true;
        }
    }

    public void ChandgeFogLifeTime(float bonus)
    {
        if (GameManager.Count_of_belok >= PriceOfUpgr2 && !isUp2)
        {
            streptoFogLifetimeBonus += bonus;
            GameManager.Count_of_belok -= PriceOfUpgr2;
            buttons[1].GetComponent<Button>().interactable = false;
            isUp2 = true;
        }
    }

    public void TuberStick_Spawn_Button()
    {
        if (GameManager.Count_of_belok >= PriceOfUpgr3 && !isUp3)
        {
            CreateTuberStick_button.SetActive(true);
            GameManager.Count_of_belok -= PriceOfUpgr3;
            buttons[2].GetComponent<Button>().interactable = false;
            isUp3 = true;
        }
    }

    public void TuberStick_Bonus(float bonus)
    {
        if (GameManager.Count_of_belok >= PriceOfUpgr4 && !isUp4)
        {
            Bacillus_attack_in_fog_bonus += bonus;
            GameManager.Count_of_belok -= PriceOfUpgr4;
            buttons[3].GetComponent<Button>().interactable = false;
            isUp4 = true;
        }
    }

    public void ChandgeAtatck_HP_Bonus(float bonusHP)
    {
        if (GameManager.Count_of_belok >= PriceOfAnti1 && !isAnti1)
        {
            AttackUnits_HPBonus += bonusHP;
            GameManager.Count_of_belok -= PriceOfAnti1;
            buttons[4].GetComponent<Button>().interactable = false;
            isAnti1 = true;
        }
    }

    public void ChandgeAtatck_Speed_Bonus(float bonusSpeed)
    {
        if (GameManager.Count_of_belok >= PriceOfAnti2 && !isAnti2)
        {
            AttackUnits_speedBonus += bonusSpeed;
            GameManager.Count_of_belok -= PriceOfAnti2;
            buttons[5].GetComponent<Button>().interactable = false;
            isAnti2 = true;
        }
    }
}
