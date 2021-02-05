using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    public float schwarzschildRadius = 400;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(schwarzschildRadius, schwarzschildRadius, schwarzschildRadius);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, schwarzschildRadius * 1.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, schwarzschildRadius * 2.6f);

        Gizmos.DrawLine(new Vector3(schwarzschildRadius * 2.6f, 0, 2000), new Vector3(schwarzschildRadius * 2.6f, 0, -2000));
        Gizmos.DrawLine(new Vector3(-schwarzschildRadius * 2.6f, 0, 2000), new Vector3(-schwarzschildRadius * 2.6f, 0, -2000));
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger:" + other.tag);
        if (other.CompareTag("Photon"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
    }


}
