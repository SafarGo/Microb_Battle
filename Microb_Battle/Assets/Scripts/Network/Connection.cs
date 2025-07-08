using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        SceneManager.LoadScene("MainMenu");
    }
}
