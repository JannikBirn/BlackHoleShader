using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViusellMovement : MonoBehaviour
{
    public float stepSize = 10;
    public float gravKonst = 6.67430f;
    public int lifetime = 20;
    private float schwarzschild;

    private Vector3 lastPosition;
    private Vector3 dirrection;

    private void Start()
    {
        schwarzschild = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<BlackHoleScript>().schwarzschildRadius;
        dirrection = transform.forward;
        lastPosition = transform.position;

        Destroy(this.gameObject, lifetime);

    }
    private void FixedUpdate()
    {
        Vector3 gravity = GetGravity();

        // Debug.Log(direction);

        transform.position += gravity * stepSize;

        dirrection = transform.position - lastPosition;
        dirrection = dirrection.normalized;
        lastPosition = transform.position;
    }

    private Vector3 GetGravity()
    {
        return (dirrection + -((transform.position * stepSize * (1.18f * schwarzschild)) / Mathf.Pow(transform.position.magnitude, 3))).normalized;
    }

    // private void OnDrawGizmos()
    // {
    //     Vector3 gravity = GetGravity();

    //     // Debug.Log(direction);

    //     Gizmos.color = Color.red;

    //     Gizmos.DrawSphere(gravity, transform.localScale.x);
    // }


}
