using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_ketogenez_UI : MonoBehaviour
{
    public GameObject zone;
    public List<GameObject> buttons = new List<GameObject>();
    public void Ket1()
    {
        GameManager.isKetognez1 = true;
        zone.SetActive(true);
        buttons[0].GetComponent<Button>().interactable = false;
    }
    public void Ket2()
    {
        GameManager.isKetognez2 = true;
        zone.transform.localScale = new Vector3(zone.transform.localScale.x * 1.2f, 1, zone.transform.localScale.z * 1.2f);
        buttons[1].GetComponent<Button>().interactable = false;
    }
    public void Ket3()
    {
        GameManager.isKetognez3 = true;
        zone.transform.localScale = new Vector3(zone.transform.localScale.x * 1.2f, 1, zone.transform.localScale.z * 1.2f);
        buttons[2].GetComponent<Button>().interactable = false;
    }
    public void Ket4()
    {
        GameManager.isKetognez4 = true;
        buttons[3].GetComponent<Button>().interactable = false;
    }
}
