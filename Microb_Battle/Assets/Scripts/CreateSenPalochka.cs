using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


public class CreateSenPalochka : MonoBehaviour
{
    bool isPressedButton = false;
    public LayerMask groundLayer;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer) && isPressedButton)
            {
                Vector3 spawnPos = hit.point;
                float distance = Vector3.Distance(new Vector3(0, 0, 0), spawnPos);
                if (distance > 13)
                {
                    PhotonNetwork.Instantiate("Sennayapalochka", spawnPos, Quaternion.identity);
                    Debug.Log(hit.collider.gameObject.layer);
                    
                }
            }
            isPressedButton = false;
        }
    }

    public void Pressed()
    {
        isPressedButton=true;
    }
}
