using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotion : MonoBehaviour
{

    [SerializeField] private GameObject EmotionPrefab;
    [SerializeField] private Transform P1_transform;

    public void SpawnEmoton(GameObject emoType)
    {
     //   if(PhotonNetwork.IsMasterClient)
     //   {
     //       GameManager.P1_Emiton = true;
     //       GameManager.P1_Emiton_Type = emoType;
     //   }
     //   else
     //   {
     //       GameManager.P2_Emiton = true;
     //       GameManager.P2_Emiton_Type = emoType;
     //   }
    }
}
