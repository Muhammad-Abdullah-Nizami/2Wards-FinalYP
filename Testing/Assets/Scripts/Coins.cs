using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{
    public Text AbilityText;
    public Text coinText;
    public actualscript actualscriptinstance;
    private int coins = 0;
    private int abilityammo = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinUI();
        UpdateAbilityUI();

        if (Input.GetButtonDown("e") || Input.GetButtonDown("f"))
        {
            if (abilityammo>0)
            {
                abilityammo--;
            }
        }
    }
    public void IncrementCoins()
    {
        coins++;
        Debug.Log("Coin increase");
        Debug.Log("Coin counter"+ coins);

    }

    public void IncrementAbility()
    {
        abilityammo++;
        Debug.Log("Ability increase");
        Debug.Log("Ability counter" + abilityammo);

    }
    public void UpdateCoinUI()
    {
       if(coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }

    public void UpdateAbilityUI()
    {
        
            AbilityText.text = "Ammo: " + abilityammo;

    }

}
