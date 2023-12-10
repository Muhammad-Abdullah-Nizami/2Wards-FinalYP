using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    private bool hasSwitched = false;

    private float startTime;

    private void Awake()
    {
        
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;

        hasSwitched = false;
        startTime = Time.time;
    }

    private void Update()
    {
        
        if (!hasSwitched && (Time.time - startTime) >= 5f)
        {
            
            camera1.enabled = false;
            camera3.enabled = true;
            camera2.enabled = true;

            
            hasSwitched = true;

            Debug.Log("Works after 5 seconds - Cameras switched.");

        }
    }

}
