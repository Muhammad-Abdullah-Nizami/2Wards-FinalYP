using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newcoins : MonoBehaviour
{
    private actualscript actualscriptinstance;
    private Coins Coinsscriptinstance;

    public AudioSource CoinSoundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
        functionbangaya();

    }
    void functionbangaya()
    {
        GameObject CoinsscriptObject = GameObject.Find("Coins");
        if (CoinsscriptObject != null)
        {
            Coinsscriptinstance = CoinsscriptObject.GetComponent<Coins>();


            if (Coinsscriptinstance == null)
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "character")
        {
            AudioSource coinSoundInstance = Instantiate(CoinSoundPrefab);
            coinSoundInstance.Play();
            Destroy(coinSoundInstance, 0.5f);
            Coinsscriptinstance.IncrementCoins();
            Destroy(gameObject);
        }
    }
}
