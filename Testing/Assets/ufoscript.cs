using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoscript : MonoBehaviour
{
    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime >= 6f)
        {
            Destroy(gameObject);
        }
    }
}
