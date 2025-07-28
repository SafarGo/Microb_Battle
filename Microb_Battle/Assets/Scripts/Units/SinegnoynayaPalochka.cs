using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.UIElements;

public class SinegnoynayaPalochka : MonoBehaviourPun, IPunObservable, IDamageable
{
    public float speed;
    public float hp;
    [SerializeField] private NavMeshAgent agent;
    public LayerMask layer;
    private bool isSelected = false;
    bool isBoomed = false;
    bool isCanMove = true;
    public int Price;
    public UnityEngine.UI.Slider Slider_hp;
    public int Count_of_belok;
    public AudioSource AudioSource;

    public float HP { get; set; } = 10f;

    public void TakeDamage(float damage)
    {

        HP -= damage;
        Slider_hp.value = HP;
        if (HP <= 0)
        {
            GameManager.towers.Remove(this.gameObject);
            object[] data = new object[] { Count_of_belok };
            PhotonNetwork.Instantiate("Belok", transform.position , Quaternion.identity, 0, data);
            PhotonNetwork.Instantiate("SynegnoynayaPalochka_Fog", new Vector3(0, 0, 3), transform.rotation);
            PhotonNetwork.Destroy(gameObject);
        }
    }

    private void Start()
    {
        agent.speed = speed;
        GameManager.Glukoza -= Price;
        GameManager.towers.Add(gameObject);
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
                    isCanMove = false;

                }
            }
        }

        if(agent.remainingDistance < 1f && agent.hasPath)
        {
            AudioSource.Play();
            object[] data = new object[] { 2 };
            PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
            PhotonNetwork.Instantiate("SynegnoynayaPalochka_Fog", transform.position, transform.rotation);
            PhotonNetwork.Destroy(gameObject);
            
        }

        
    }

    private void OnMouseDown()
    {
        if (photonView.IsMine && isCanMove)
            isSelected = true;
    }

    // Реализация IPunObservable
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Мы отправляем данные другим игрокам
            stream.SendNext(hp);
            stream.SendNext(transform.position);
        }
        else
        {
            // Мы получаем данные от владельца объекта
            hp = (float)stream.ReceiveNext();
            Vector3 receivedPosition = (Vector3)stream.ReceiveNext();
            // Плавно двигаем объект к полученной позиции
            if (!photonView.IsMine)
                transform.position = Vector3.Lerp(transform.position, receivedPosition, Time.deltaTime * 10);
        }
    }
}