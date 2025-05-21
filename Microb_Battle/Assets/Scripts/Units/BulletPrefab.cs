using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    [SerializeField] private float speed;



    private void Update()
    {
        if (transform.parent.GetComponent<PlazmocitController>()._target != null)
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetComponent<PlazmocitController>()._target.transform.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StafiloccocsController st = other.gameObject.GetComponent<StafiloccocsController>();
            st.lives -= 20f;
            Destroy(gameObject);
        }
    }
}
