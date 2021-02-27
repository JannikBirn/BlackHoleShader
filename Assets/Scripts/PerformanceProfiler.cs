using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceProfiler : MonoBehaviour
{
    public float showFPSAfterSec = 1;
    private float minFPS, avgFPS, maxFPS;

    private int fpsCounter = 10;
    private int counter;
    private float fps;

    public Text min, avg, max;

    private void Start()
    {
        StartCoroutine(CountFPS());
        //set min fps to high value so it will be overwritten
        minFPS = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        //Adding current fps
        if (counter > fpsCounter)
        {
            avgFPS = fps / fpsCounter;
            fps = 0;
            counter = 0;
        }

        float currentFps = 1f / Time.deltaTime;
        fps += currentFps;
        if (currentFps < minFPS)
        {
            minFPS = currentFps;
        }
        if (currentFps > maxFPS)
        {
            maxFPS = currentFps;
        }

        counter++;
    }

    IEnumerator CountFPS()
    {
        yield return new WaitForSecondsRealtime(showFPSAfterSec);
        min.text = "Min:" + minFPS.ToString("n2");
        max.text = "Max:" + maxFPS.ToString("n2"); ;
        avg.text = "Avg:" + avgFPS.ToString("n2"); ;
        // Debug.Log($"FPS Min:{minFPS}  Avg:{avgFPS}  Max:{maxFPS}");
        StartCoroutine(CountFPS());
    }
}