
using UnityEngine;
using Photon.Pun;
public class NetworkGameSystem : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _player;

    void Awake()
    {
        PhotonNetwork.Instantiate(_player.name, Vector3.zero, Quaternion.identity);
    }
}
