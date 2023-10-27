using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    //neeche k do main path k liyai
    public Transform tileObj;
    private Vector3 nextTileSpawn;
    //yahan tk main tile ka k variables hain

    public Transform secondPath;

    public Transform invisiObj;
    private Vector3 nextinvisispawn;

    //ab obstacles k instantiation k liyai variables, traffic cone wala obstacle
    public Transform doneTconeObj;
    private Vector3 nextTconeSpawn;

    public Transform Lowbarrierobj;
    private Vector3 nextLowbarrierSpawn;

    public Transform thirdObstacleObj;

    public int spawnCount = 0; 
    private bool spawnRoad1 = true;

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

    // new spawnInvisi function. Made it BETTER, STRONGER, FASTTTER, and with one more obstacle :D
    IEnumerator spawnInvisi()
    {
        yield return new WaitForSeconds(1);
        nextTconeSpawn = nextinvisispawn;

        //trying to get objects to spawn at different z locaion of the invisiObj
        

        float invisiObjLength = 6.0f;
        float randZ = Random.Range(0f, invisiObjLength);
        nextTconeSpawn.z = nextinvisispawn.z + randZ;


        float[] possibleXValues = new float[] { -2.5f, 0f, 2.5f };
        float randX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        nextTconeSpawn.x = randX;

        Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);

        int randObstacle = Random.Range(0, 3);

        if (randObstacle == 0)
        {
            Instantiate(doneTconeObj, nextTconeSpawn, doneTconeObj.rotation);
        }
        else if (randObstacle == 1)
        {
            nextTconeSpawn.y = 0.54f;
            Instantiate(Lowbarrierobj, nextTconeSpawn, Lowbarrierobj.rotation);
        }
        else if (randObstacle == 2)
        {
            nextTconeSpawn.y = 0.7f;
            Instantiate(thirdObstacleObj, nextTconeSpawn, thirdObstacleObj.rotation);
        }

        nextinvisispawn.z += 6;
        StartCoroutine(spawnInvisi());
    }

    //original spawnInvisi function below

    //IEnumerator spawnInvisi()
    //{

    //    //explain to partnerss
    //    yield return new WaitForSeconds(2);
    //    nextTconeSpawn = nextinvisispawn;

    //    RandX = Random.Range(0, 3);

    //    if (RandX == 0)
    //    {
    //        nextTconeSpawn.x = -2.5f;
    //    }
    //    else if (RandX == 1)
    //    {
    //        nextTconeSpawn.x = 0f;
    //    }
    //    else if (RandX == 2)
    //    {
    //        nextTconeSpawn.x = 2.5f;
    //    }

    //    Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);
    //    Instantiate(doneTconeObj, nextTconeSpawn, doneTconeObj.rotation);

    //    nextinvisispawn.z += 6;
    //    RandY = Random.Range(0, 3);
    //    if (RandY == 0)
    //    {
    //        nextLowbarrierSpawn.x = -2.5f;
    //    }
    //    else if (RandY == 1)
    //    {
    //        nextLowbarrierSpawn.x = 0f;
    //    }
    //    else if (RandY == 2)
    //    {
    //        nextLowbarrierSpawn.x = 2.5f;
    //    }
    //    nextLowbarrierSpawn.z = nextinvisispawn.z;
    //    nextLowbarrierSpawn.y = 0.54f;
    //    Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);
    //    Instantiate(Lowbarrierobj, nextLowbarrierSpawn, Lowbarrierobj.rotation);
    //    nextinvisispawn.z += 6;
    //    StartCoroutine(spawnInvisi());


    //}
    IEnumerator spawnTile()
    {
        //yield return new WaitForSeconds(6); // main path spawn krne ka wait time
        //Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        //nextTileSpawn.z += 30;
        //StartCoroutine(spawnTile()); // infinite loop k liyai

        while (spawnCount < 10) // We want to spawn a total of 10 times (5 road1 + 5 road2)
        {
            if (spawnRoad1)
            {
                Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
            }
            else
            {
                Instantiate(secondPath, nextTileSpawn, secondPath.rotation);
            }

            nextTileSpawn.z += 30;
            spawnCount++;

            if (spawnCount % 5 == 0)
            {
                // After every 5 spawns, switch to the other road type
                spawnRoad1 = !spawnRoad1;
            }
            if (spawnCount >=10)
            {
                spawnCount = 0;
            }

            yield return new WaitForSeconds(6f);
        }

    }
}