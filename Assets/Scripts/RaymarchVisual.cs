using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaymarchVisual : MonoBehaviour
{
    public float mass;
    public float maxSteps;
    public float stepSize;
    public float grav;
    float currSteps;
    public Color color = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currSteps=0;
        Raymarch(transform.position, transform.forward);
    }

   

    void Raymarch(Vector3 pos, Vector3 dir)
    {
        float force = (grav*mass) / (pos.sqrMagnitude);//Schwarzes Loch im Ursprung
        Vector3 force3 =  Vector3.Normalize(-pos)*force;
        Vector3 newDir = Vector3.Normalize(dir + force3)*stepSize;
        Debug.DrawRay(pos, newDir, color);
        Vector3 newPos = pos+newDir;
        currSteps++;
        if (currSteps<maxSteps && newPos.magnitude>stepSize)
        {
            Raymarch(newPos, newDir);
        }
    }
}
