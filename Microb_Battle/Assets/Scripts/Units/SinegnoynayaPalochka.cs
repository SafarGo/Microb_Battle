using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SinegnoynayaPalochka : MonoBehaviourPun, IPunObservable
{
    public float speed;
    public float hp;
    public float damage;
    [SerializeField] private NavMeshAgent agent;
    public LayerMask layer;
    private bool isSelected = false;
    bool isBoomed = false;


    private void Start()
    {
        agent.speed = speed;
        GameManager.Glukoza -= 3;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        if (isSelected && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layer))
            {
                if (hit.transform != transform)
                {
                    agent.SetDestination(hit.point);
                    isSelected = false;
                    StartCoroutine(Ding());
                    
                }
            }
        }
        if(hp==0 && !isBoomed)
        {
            isBoomed=true;
        }
    }

    IEnumerator Ding()
    {
        yield return new WaitForSeconds(1);
        hp = 0;
        object[] data = new object[] { 2 };
        PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
        Debug.Log("Die");
    }

    private void OnMouseDown()
    {
        if (photonView.IsMine)
            isSelected = true;
    }

    // Реализация IPunObservable
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Мы отправляем данные другим игрокам
            stream.SendNext(hp);
            stream.SendNext(damage);
            stream.SendNext(transform.position);
        }
        else
        {
            // Мы получаем данные от владельца объекта
            hp = (float)stream.ReceiveNext();
            damage = (float)stream.ReceiveNext();
            Vector3 receivedPosition = (Vector3)stream.ReceiveNext();
            // Плавно двигаем объект к полученной позиции
            if (!photonView.IsMine)
                transform.position = Vector3.Lerp(transform.position, receivedPosition, Time.deltaTime * 10);
        }
    }
}