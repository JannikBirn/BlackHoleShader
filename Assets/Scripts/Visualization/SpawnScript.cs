using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 offset = Vector3.zero;
    public int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject particle = Instantiate(prefab, GetPosition(i), Quaternion.identity, this.transform);
            // Debug.Log(Color.HSVToRGB(1f / count * i, 1f, 1f));
            TrailRenderer trail = particle.GetComponent<TrailRenderer>();
            if (trail)
                trail.endColor = Color.HSVToRGB(1f / count * i, 1f, 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < count; i++)
        {
            Gizmos.DrawSphere(GetPosition(i), 0.5f);
        }

    }

    private Vector3 GetPosition(int index)
    {
        return transform.position + offset * index;
    }
}
