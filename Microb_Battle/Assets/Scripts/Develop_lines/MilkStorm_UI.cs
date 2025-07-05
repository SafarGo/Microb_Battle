using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkStorm_UI : MonoBehaviour
{
    public ParticleSystem sys;

    private void Start()
    {
        sys.GetComponent<ParticleSystem>();
    }
    public void OnClickButton()
    {
        if(GameManager.isMilkStorm1 == false)
        {
            return;
        }
        else if(GameManager.isMilkStorm1)
        {
            MilkStorm_line.instance.Storm1();
        }
        else if(GameManager.isMilkStorm2)
        {
            MilkStorm_line.instance.Storm2();
        }
        else if (GameManager.isMilkStorm3)
        {
            MilkStorm_line.instance.Storm3();
        }
        sys.Play();
    }
}
