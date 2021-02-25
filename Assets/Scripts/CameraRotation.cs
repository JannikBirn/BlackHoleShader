using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationValue;
    private Vector3 rotationSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = new Vector3(0, -rotationValue * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed);
    }
}
