using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformController : MonoBehaviour
{
    private void Update()
    {
        float sinWave = Mathf.Sin(Time.time);
        Debug.Log(sinWave);
    }
}
