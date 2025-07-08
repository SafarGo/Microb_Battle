using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviourPunCallbacks
{
    public float panSpeed = 20f;
    public float panBorderTikness = 50f;
    public Vector2 panLimit;
    private PhotonView phtonView;
    private void Start()
    {
        phtonView = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height- panBorderTikness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderTikness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderTikness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderTikness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
            pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;        
    }
    void FixedUpdate()
    {
        if (Input.mousePosition.x >= Screen.width - Screen.width / 5.5f
            || Input.mousePosition.x <= Screen.width / 5.5f)
        {
            GameManager.isCanSelectTower = false;
        }
        else
        {
            GameManager.isCanSelectTower = true;
        }
    }
}
