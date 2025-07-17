using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_segment_Controller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Palochka"))
        Destroy(gameObject);
    }


}
