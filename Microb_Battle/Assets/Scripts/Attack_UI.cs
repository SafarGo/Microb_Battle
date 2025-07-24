using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attack_UI : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public List<int> prices = new List<int>();
    public TMP_Text text_of_beloks;
    public Slider Slider;
    private void Start()
    {
        for(int i = 0; i<buttons.Count; i++) 
            {
            buttons[i].interactable = false;
            }
    }

    private void FixedUpdate()
    {
        for(int i = 0; i<buttons.Count; i++)
        {
            Check(i);
        }
        text_of_beloks.text = GameManager.Count_of_belok.ToString();
        Slider.value = GameManager.Count_of_belok;
    }

    void Check(int index)
    {
        if (index < 5)
        {
            if (GameManager.Count_of_belok >= prices[index])
            {
                buttons[index].interactable = true;
            }
            else
                buttons[index].interactable = false;

        }
        else
        {
            switch (index)
            {
                case 5:
                    if (!Enemy_Upgrade_Units.isUp1 && GameManager.Count_of_belok >= prices[index])
                    {
                        buttons[index].interactable = true;
                    }
                    break;
                case 6:
                    if (!Enemy_Upgrade_Units.isUp2 && GameManager.Count_of_belok >= prices[index] && Enemy_Upgrade_Units.isUp1)
                    {
                        buttons[index].interactable = true;
                    }
                    break;
                case 7:
                    if (!Enemy_Upgrade_Units.isUp3 && GameManager.Count_of_belok >= prices[index] && Enemy_Upgrade_Units.isUp1)
                    {
                        buttons[index].interactable = true;
                    }
                    break;
                case 8:
                    if (!Enemy_Upgrade_Units.isUp4 && GameManager.Count_of_belok >= prices[index] && Enemy_Upgrade_Units.isUp2 && Enemy_Upgrade_Units.isUp3)
                    {
                        buttons[index].interactable = true;
                    }
                    break;
                case 9:
                    if (!Enemy_Upgrade_Units.isAnti1 && GameManager.Count_of_belok >= prices[index])
                    {
                        buttons[index].interactable = true;
                    }
                    break;
                case 10:
                    if (!Enemy_Upgrade_Units.isAnti2 && GameManager.Count_of_belok >= prices[index])
                    {
                        buttons[index].interactable = true;
                    }
                    break;
            }
        }
    }
}
