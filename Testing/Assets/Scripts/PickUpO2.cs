using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpO2 : MonoBehaviour
{
    private Player PlayerScriptInstance;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
        GameObject PlayerScriptObject = GameObject.Find("healthbarobject");

        // Check if the GameObject was found
        if (PlayerScriptObject != null)
        {
            // Try to get the ActualScript component from the found GameObject
            PlayerScriptInstance = PlayerScriptObject.GetComponent<Player>();

            // Check if the component was found
            if (PlayerScriptInstance == null)
            {
                Debug.LogError("Player script component not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with Player script not found.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "character")
        {
            Destroy(gameObject);
            PlayerScriptInstance.MaxHealth();
        }
    }
}
