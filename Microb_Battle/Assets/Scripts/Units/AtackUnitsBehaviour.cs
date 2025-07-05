using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackUnitsBehaviour : MonoBehaviour
{
    public static AtackUnitsBehaviour AUB { get; private set; }
    [SerializeField] private GameObject stafilococFogPrefab;
    private void Awake()
    {
        if (AUB == null)
        {
            AUB = this;
        }
    }

    public void Death(GameObject unit,string unitType)
    {
        GameManager.Glukoza += 5;
        GameManager.count_of_dead_enemies++;
        Destroy(unit);
        switch (unitType)
        {
            default:
                Debug.Log("���������� �����");
                break;

            case "Stafilococ":
                Debug.Log("���������� �����");
                break;
            case "Streptococ":
                Debug.Log("���������� �����");
                Instantiate(stafilococFogPrefab, unit.transform.position,Quaternion.identity);
                break;


        }
    }
}
