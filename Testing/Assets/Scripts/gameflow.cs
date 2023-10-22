using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    //neeche k do main path k liyai
    public Transform tileObj;
    private Vector3 nextTileSpawn;
    //yahan tk main tile ka k variables hain

    public Transform invisiObj;
    private Vector3 nextinvisispawn;

    //ab obstacles k instantiation k liyai variables, traffic cone wala obstacle
    public Transform doneTconeObj;
    private Vector3 nextTconeSpawn;

    public Transform Lowbarrierobj;
    private Vector3 nextLowbarrierSpawn;

    private float RandX;    //random number variable obsatcles ko spawn krnai k liyai
    private float RandY;    //random number variable obsatcles ko spawn krnai k liyai

    void Start()
    {

        nextTileSpawn.z = 90; //humne position di hai first new spawn ki main path k
        nextinvisispawn.z = 18;
        StartCoroutine(spawnTile()); //issey neeche ka spawntile loop shuru hojaiga
        StartCoroutine(spawnInvisi());
    }

    
    void Update()
    {

    }

    IEnumerator spawnInvisi() 
    {

        //explain to partnerss
        yield return new WaitForSeconds(2);
        nextTconeSpawn = nextinvisispawn;

        RandX = Random.Range(0, 3);

        if (RandX == 0)
        {
            nextTconeSpawn.x = -2.5f; 
        }
        else if (RandX == 1)
        {
            nextTconeSpawn.x = 0f;    
        }
        else if (RandX == 2)
        {
            nextTconeSpawn.x = 2.5f; 
        }
        
        Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);
        Instantiate(doneTconeObj, nextTconeSpawn, doneTconeObj.rotation);

        nextinvisispawn.z += 6;
        RandY = Random.Range(0, 3);
        if (RandY == 0)
        {
            nextLowbarrierSpawn.x = -2.5f; 
        }
        else if (RandY == 1)
        {
            nextLowbarrierSpawn.x = 0f;    
        }
        else if (RandY == 2)
        {
            nextLowbarrierSpawn.x = 2.5f; 
        }
        nextLowbarrierSpawn.z= nextinvisispawn.z;
        nextLowbarrierSpawn.y = 0.54f;
        Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);
        Instantiate(Lowbarrierobj, nextLowbarrierSpawn, Lowbarrierobj.rotation);
        nextinvisispawn.z += 6;
        StartCoroutine(spawnInvisi());


    }
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(6); // main path spawn krne ka wait time
        Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        nextTileSpawn.z += 30;
        StartCoroutine(spawnTile()); // infinite loop k liyai

    }
}
