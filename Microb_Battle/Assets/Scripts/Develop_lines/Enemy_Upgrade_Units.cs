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
    public  void ChandgeKlostAttackBunus(float bonus)
    {
        klostrydyy_attack_bonus += bonus;
        GameManager.Count_of_belok -= PriceOfAnti1;
        buttons[0].GetComponent<Button>().interactable = false;
    }

    public  void ChandgeFogLifeTime(float bonus)
    {
        streptoFogLifetimeBonus += bonus;
        GameManager.Count_of_belok -= PriceOfAnti2;
        buttons[1].GetComponent<Button>().interactable = false;
    }

    public  void ChandgeAtatck_HP_Bonus(float bonusHP)
    {
        AttackUnits_HPBonus += bonusHP;
        GameManager.Count_of_belok -= PriceOfUpgr1;
        buttons[4].GetComponent<Button>().interactable = false;
    }

    public  void ChandgeAtatck_Speed_Bonus(float bonusSpeed)
    {
        AttackUnits_speedBonus += bonusSpeed;
        GameManager.Count_of_belok -= PriceOfUpgr2;
        buttons[5].GetComponent<Button>().interactable = false;
    }

    public void TuberStick_Spawn_Button()
    {
        if (CreateTuberStick_button != null)
            CreateTuberStick_button.SetActive(true);
        GameManager.Count_of_belok -= PriceOfUpgr3;
        buttons[2].GetComponent<Button>().interactable = false;
    }

    public void TuberStick_Bonus(float bonus)
    {
        Bacillus_attack_in_fog_bonus += bonus;
        GameManager.Count_of_belok -= PriceOfUpgr4;
        buttons[3].GetComponent<Button>().interactable = false;
    }
}
