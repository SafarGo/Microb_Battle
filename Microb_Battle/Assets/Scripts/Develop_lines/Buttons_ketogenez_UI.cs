using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_ketogenez_UI : MonoBehaviour
{
    public GameObject zone;
    public List<GameObject> buttons = new List<GameObject>();
    int level_of_ketogenez = 0;
    public void Ket1()
    {
        GameManager.isKetognez1 = true;
        zone.SetActive(true);
        buttons[0].GetComponent<Button>().interactable = false;
        level_of_ketogenez++;
        buttons[1].GetComponent<Button>().interactable = true;
        buttons[2].GetComponent<Button>().interactable = true;
    }
    public void Ket2()
    {
        GameManager.isKetognez2 = true;
        zone.transform.localScale = new Vector3(zone.transform.localScale.x * 1.2f, 1, zone.transform.localScale.z * 1.2f);
        buttons[1].GetComponent<Button>().interactable = false;
        if(GameManager.isKetognez3)
            buttons[3].GetComponent<Button>().interactable = true;
    }
    public void Ket3()
    {
        GameManager.isKetognez3 = true;
        zone.transform.localScale = new Vector3(zone.transform.localScale.x * 1.2f, 1, zone.transform.localScale.z * 1.2f);
        buttons[2].GetComponent<Button>().interactable = false;
        if (GameManager.isKetognez2)
            buttons[3].GetComponent<Button>().interactable = true;
    }
    public void Ket4()
    {
        GameManager.isKetognez4 = true;
        buttons[3].GetComponent<Button>().interactable = false;
    }
}
