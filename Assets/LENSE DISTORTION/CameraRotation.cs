using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    Vector3 rotationSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = new Vector3(0, -10 * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed);
    }
}
