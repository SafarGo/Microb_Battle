using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMoveing : NetworkBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!isLocalPlayer) return;
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }
}
