using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkStorm_UI : MonoBehaviour
{
    public ParticleSystem sys;
    bool activate_storm = false;

    private void Start()
    {
    }
    public void OnClickButton()
    {
        activate_storm = false;
        if (!GameManager.isMilkStorm1 && !GameManager.isMilkStorm2 && !GameManager.isMilkStorm3)
        {
            return;
        }
        else if(GameManager.isMilkStorm1)
        {
            MilkStorm_line.instance.Storm1();
            activate_storm = true;

        }
        else if(GameManager.isMilkStorm2)
        {
            MilkStorm_line.instance.Storm2();
            activate_storm = true;
        }
        else if (GameManager.isMilkStorm3)
        {
            MilkStorm_line.instance.Storm3();
            activate_storm = true;
        }
        if(activate_storm)
        sys.Play();
    }
}
