using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerCanvasController : MonoBehaviour
{
    [SerializeField] private PhotonView photonView; 
    [SerializeField] private GameObject objectToInstantiate; 
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.isAttacker)
        {
            if (photonView.IsMine)
            {
                Debug.Log("isAttacker: " + GameManager.isAttacker);
                Destroy(gameObject);
            }
            
        }
    }

    private void LateUpdate()
    {
        if (GameManager.isAttacker)
        {
            //if (photonView.IsMine)
            //{
            Debug.Log("isAttacker: " + GameManager.isAttacker);
            if (objectToInstantiate != null)
            {
                Instantiate(objectToInstantiate, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
            //}

        }
    }
}
