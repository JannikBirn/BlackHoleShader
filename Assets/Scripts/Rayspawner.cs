using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayspawner : MonoBehaviour
{

    public int sizeX;
    public int sizeY;
    public float offset;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                GameObject ray = Instantiate(prefab,transform.position + new Vector3(i*offset,j*offset,0), Quaternion.identity, this.transform);
                RaymarchVisual rayVis = ray.GetComponent<RaymarchVisual>();
                rayVis.color= new Color(1f / sizeY * j, 1f / sizeX * i, 0.3f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
