using UnityEngine;
using System.Collections;

public class PresentationScript : MonoBehaviour
{
    private GestureListener gestureListener;
    private actualscript actualscriptinstance;

    void Start()
    {
        if (gestureListener == null)
        {
            Debug.LogError("GestureListener not assigned.");
        }

        gestureListener = GetComponent<GestureListener>();

        FindActualScript();
    }

    void Update()
    {
        if (gestureListener != null)
        {
            HandleGestures();
        }
        else
        {
            Debug.LogWarning("GestureListener is null. Make sure it is assigned.");
        }
    }

    void HandleGestures()
    {
        if (gestureListener.IsSwipeLeft())
        {
            if (actualscriptinstance != null)
            {
                actualscriptinstance.MoveLeft();
                Debug.Log("SwipeLeft Gesture Detected");
            }
            else
            {
                Debug.LogWarning("actualscriptinstance is null. Make sure it is assigned.");
            }
        }
        else if (gestureListener.IsSwipeRight())
        {
            if (actualscriptinstance != null)
            {
                actualscriptinstance.MoveRight();
                Debug.Log("SwipeRight Gesture Detected");
            }
            else
            {
                Debug.LogWarning("actualscriptinstance is null. Make sure it is assigned.");
            }
        }
    }

    void FindActualScript()
    {
        GameObject actualscriptObject = GameObject.Find("astronoutTPOSE");
        if (actualscriptObject != null)
        {
            actualscriptinstance = actualscriptObject.GetComponent<actualscript>();

            if (actualscriptinstance == null)
            {
                Debug.LogError("actualscript component not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with actualscript not found.");
        }
    }
}
