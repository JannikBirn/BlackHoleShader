using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public Transform target;
    public Vector3 dirrection;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, dirrection.y * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.forward, dirrection.z * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.right, dirrection.x * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }
}