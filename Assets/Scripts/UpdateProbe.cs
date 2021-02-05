using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UpdateProbe : MonoBehaviour
{
    public ReflectionProbe reflection;

    // Update is called once per frame
    void Update()
    {
        reflection.RenderProbe();
    }
}
