using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    public static float time = 300f;
    [SerializeField] private TMP_Text text;
    public GameObject Player_1_Win;
    private PhotonView photonView;

    private void Start()
    {
        //photonView = gameObject.GetComponent<PhotonView>();
        //if (!PhotonNetwork.IsMasterClient) { Destroy(this); }
        time = 900f;
        //InvokeRepeating(, 0, 1);
    }
    private void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount != 2) { return; } 
        time -= Time.deltaTime;
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        text.text = $"{minutes:00}:{seconds:00}";
        if(time<=0 && !GameManager.isGameOver)
        {
           Player_1_Win.SetActive(true);
        }
    }

    //public void SyncTime()
    //{
    //    photonView.RPC("UpdateHealth", RpcTarget.Others, lives);
    //}
    //[PunRPC]
    //public void UpdateTime(float newTime)
    //{
    //    lives = newHealth;
    //    _slider.value = lives;
    //}
}
