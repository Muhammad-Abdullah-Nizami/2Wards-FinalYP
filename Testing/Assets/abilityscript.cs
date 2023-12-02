using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityscript : MonoBehaviour
{
    private actualscript actualscriptinstance;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
        functionbangaya();
    }

    void functionbangaya()
    {
        GameObject actualscriptObject = GameObject.Find("astronoutTPOSE");
        if (actualscriptObject != null)
        {
            actualscriptinstance = actualscriptObject.GetComponent<actualscript>();


            if (actualscriptinstance == null)
            {
                Debug.LogError("abilityscript component not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with abilityscript not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void counterincrease()
    //{
    //    abilitycounter++;
    //    Debug.Log("Ability counter icreased");
    //    Debug.Log(abilitycounter);
    //}
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "character")
        {
            actualscriptinstance.counterincrease();
            Destroy(gameObject);
        }
    }
}
