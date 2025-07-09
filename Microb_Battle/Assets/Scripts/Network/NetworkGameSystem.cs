
using UnityEngine;
using Photon.Pun;
public class NetworkGameSystem : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _player;

    void Awake()
    {
        PhotonNetwork.Instantiate(_player.name, new Vector3(0, 14.5f, 0), Quaternion.Euler(60,0,0));
    }
}
