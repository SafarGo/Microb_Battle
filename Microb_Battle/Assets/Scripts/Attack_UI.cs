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
        if (GameManager.Count_of_belok > prices[0])
        {
            buttons[0].interactable = true;
        }
        else
            buttons[0].interactable = false;
        if (GameManager.Count_of_belok > prices[1])
        {
            buttons[1].interactable = true;
        }
        else buttons[1].interactable = false;
        if (GameManager.Count_of_belok > prices[2])
        {
            buttons[2].interactable = true;
        }
        else buttons[2].interactable = false;
        if (GameManager.Count_of_belok > prices[3])
        {
            buttons[3].interactable = true;
        }
        else buttons[3].interactable = false;
        if (GameManager.Count_of_belok > prices[4])
        {
            buttons[4].interactable = true;
        }
        else buttons[4].interactable = false;
        text_of_beloks.text = GameManager.Count_of_belok.ToString();
        Slider.value = GameManager.Count_of_belok;
    }
}
