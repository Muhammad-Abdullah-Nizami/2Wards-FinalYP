using UnityEngine;
using System.Collections;

public class PresentationScript : MonoBehaviour
{
    private GestureListener gestureListener;
    private actualscript actualscriptinstance;

    void Start()
    {
        Cursor.visible = true;
        // Try to get the GestureListener component from the same GameObject
        gestureListener = GetComponent<GestureListener>();

        if (gestureListener == null)
        {
            Debug.LogError("GestureListener not found on the same GameObject.");
        }

        FindActualScript();
    }

    void Update()
    {
        // Check if KinectManager is initialized and a user is detected
        KinectManager kinectManager = KinectManager.Instance;
        if (!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected())
            return;

        //// Now proceed with gesture handling
        //if (gestureListener)
        //{
            HandleGestures();
        //}
        //else
        //{
        //    Debug.LogWarning("GestureListener is null. Make sure it is assigned.");
        //}
    }

    void HandleGestures()
    {
        // Your existing code for handling gestures
        if (gestureListener.IsSwipeLeft())
        {
            //if (actualscriptinstance != null)
            //{
                actualscriptinstance.MoveLeft();
                Debug.Log("SwipeLeft Gesture Detected");
            //}
            //else
            //{
            //    Debug.LogWarning("actualscriptinstance is null. Make sure it is assigned.");
            //}
        }
        else if (gestureListener.IsSwipeRight())
        {
            //if (actualscriptinstance != null)
            //{
                actualscriptinstance.MoveRight();
                Debug.Log("SwipeRight Gesture Detected");
            //}
            //else
            //{
            //    Debug.LogWarning("actualscriptinstance is null. Make sure it is assigned.");
            //}
        }

        else if (gestureListener.IsJump())
        {

            actualscriptinstance._velocity.y = actualscriptinstance.jumpspeed;
            actualscriptinstance.theanimator.SetTrigger("jump");
            Debug.Log("JUMP Gesture Detected");
            Debug.Log("JUMP Gesture Detected");
            Debug.Log("JUMP Gesture Detected");


        }
        else
        {
            actualscriptinstance._velocity.y = 0f;
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
