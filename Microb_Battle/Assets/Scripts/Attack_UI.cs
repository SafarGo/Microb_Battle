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
        Check(0);
        Check(1);
        Check(2);
        Check(3);
        text_of_beloks.text = GameManager.Count_of_belok.ToString();
        Slider.value = GameManager.Count_of_belok;
    }

    void Check(int index)
    {
        if (GameManager.Count_of_belok > prices[index])
        {
            buttons[index].interactable = true;
        }
        else
            buttons[index].interactable = false;
    }
}
