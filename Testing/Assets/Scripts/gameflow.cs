using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    //neeche k do main path k liyai
    public Transform tileObj;
    private Vector3 nextTileSpawn;
    //yahan tk main tile ka k variables hain

    public Transform secondPath;


    //ab obstacles k instantiation k liyai variables, traffic cone wala obstacle
    public Transform firstObj
        ;
    private Vector3 nextTconeSpawn;

    public Transform secondObj;
    
    public Transform thirdObj;

    //adding new obstacles 
    public Transform leftsign;
    public Transform rightsign;
    public Transform targetsign;   

    public int spawnCount = 3;
    private bool spawnRoad1 = true;

    private bool isNight = true;
    public float invisiObjLength = 6.0f;

    //changes for ayman

    List<float> usedZPositions = new List<float>();


    void Start()
    {

        nextTileSpawn.z = 90; //humne position di hai first new spawn ki main path k
        
        StartCoroutine(spawnTile()); //issey neeche ka spawntile loop shuru hojaiga
        //StartCoroutine(spawnInvisi());
        //trying the ew method
        //StartCoroutine(decide());

    }


    void Update()
    {
        
        //this all was just for testing if it works, it does.
        //if (isNight)
        //{
        //    Debug.Log("IsNight");
        //}

        //else
        //{
        //    Debug.Log("is day");
        //}
    }


    //2/11/23 removed the entire concept of this spawninvisi function. Added spawnDayostacle and spawnnightobstacle instead
    //and called them in the path instantiating fucniton of spawntile
    // new spawnInvisi function. Made it BETTER, STRONGER, FASTTTER, and with one more obstacle :D
    //IEnumerator spawnInvisi()
    //{
    //    yield return new WaitForSeconds(1);
    //    nextTconeSpawn = nextinvisispawn;

    //    //trying to get objects to spawn at different z locaion of the invisiObj
        

        
    //    float randZ = Random.Range(0f, invisiObjLength);
    //    nextTconeSpawn.z = nextinvisispawn.z + randZ;


    //    float[] possibleXValues = new float[] { -2.5f, 0f, 2.5f };
    //    float randX = possibleXValues[Random.Range(0, possibleXValues.Length)];
    //    nextTconeSpawn.x = randX;

    //    Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);

    //    int randObstacle = Random.Range(0, 3);

    //    if (randObstacle == 0)
    //    {
    //        nextTconeSpawn.y = 1.2f;
    //        Instantiate(doneTconeObj, nextTconeSpawn, doneTconeObj.rotation);
    //    }
    //    else if (randObstacle == 1)
    //    {
    //        nextTconeSpawn.y = 1.2f;
    //        Instantiate(Lowbarrierobj, nextTconeSpawn, Lowbarrierobj.rotation);
    //    }
    //    else if (randObstacle == 2)
    //    {
            
    //        Instantiate(thirdObstacleObj, nextTconeSpawn, thirdObstacleObj.rotation);
    //    }

    //    nextinvisispawn.z += 6;
    //    StartCoroutine(spawnInvisi());
    //}

    //IEnumerator NextspawnInvisi()
    //{
    //    yield return new WaitForSeconds(1);
    //    nextTconeSpawn = nextinvisispawn;

    //    //trying to get objects to spawn at different z locaion of the invisiObj
        

    //    float invisiObjLength = 6.0f;
    //    float randZ = Random.Range(0f, invisiObjLength);
    //    nextTconeSpawn.z = nextinvisispawn.z + randZ;


    //    float[] possibleXValues = new float[] { -2.5f, 0f, 2.5f };
    //    float randX = possibleXValues[Random.Range(0, possibleXValues.Length)];
    //    nextTconeSpawn.x = randX;

    //    Instantiate(invisiObj, nextinvisispawn, invisiObj.rotation);

    //    int randObstacle = Random.Range(0, 3);

    //    if (randObstacle == 0)
    //    {
    //        nextTconeSpawn.y = 1.2f;
    //        Instantiate(leftsign, nextTconeSpawn, doneTconeObj.rotation);
    //    }
    //    else if (randObstacle == 1)
    //    {
    //        nextTconeSpawn.y = 1.2f;
    //        Instantiate(rightsign, nextTconeSpawn, Lowbarrierobj.rotation);
    //    }
    //    else if (randObstacle == 2)
    //    {
            
    //        Instantiate(targetsign, nextTconeSpawn, thirdObstacleObj.rotation);
    //    }

    //    nextinvisispawn.z += 6;
    //    StartCoroutine(NextspawnInvisi());
    //}

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

                for (int i = 0; i < 4; i++)
                {
                    spawnnightObstacle();
                }

            }
            else
            {
                
                Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
                
                for (int i = 0; i < 4; i++)
                {
                    //spawndayObstacle();
                    spawnnightObstacle();
                }
            }

            nextTileSpawn.z += 30;
            spawnCount++;

            if (spawnCount % 5 == 0)
            {
                // After every 5 spawns, switch to the other road type
                spawnRoad1 = !spawnRoad1;
                isNight = !isNight; //added for use later i guess
            }
            if (spawnCount >=10)
            {
                spawnCount = 0;
            }

            yield return new WaitForSeconds(4f);
        }

    }


    void spawndayObstacle()
    {
        nextTconeSpawn = nextTileSpawn;
        float[] possibleXValues = new float[] { -2.5f, 0f, 2.5f };
        float randX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        nextTconeSpawn.x = randX;

        float[] possibleZValues = new float[] { -10f,-6.5f, -5f, 3f, 0f, 5f, 6.5f, 10f, -15f, 15f};
        float[] availableZValues = possibleZValues.Except(usedZPositions).ToArray();

        // Check if there are any available z positions left.
        if (availableZValues.Length == 0)
        {
            // All z positions have been used.
            usedZPositions.Clear();
            availableZValues = possibleZValues; // Use all possible z values again.
        }

        float randZ = availableZValues[Random.Range(0, availableZValues.Length)];

        // Add the newly used z position to the list.
        usedZPositions.Add(randZ);

        //float randZ = Random.Range(-10f, 10);
        nextTconeSpawn.z = nextTconeSpawn.z + randZ;

        //NOTE FOR AYMAN, ADD RANDOM ARRAY FILLED WITH GOOD VALUES INSTEAD OF THIS RANDOM RANGE.


        int randObstacle = Random.Range(0, 3);

        if (randObstacle == 0)
        {
            nextTconeSpawn.y = 0.27f;
            Instantiate(leftsign, nextTconeSpawn, leftsign.rotation);
        }
        else if (randObstacle == 1)
        {
            nextTconeSpawn.y = 0.53f;
            Instantiate(rightsign, nextTconeSpawn, rightsign.rotation);
        }
        else if (randObstacle == 2)
        {
            nextTconeSpawn.y = 0.53f;
            Instantiate(targetsign, nextTconeSpawn, targetsign.rotation);
        }

        

    }


    void spawnnightObstacle()
    {
        nextTconeSpawn = nextTileSpawn;
        float[] possibleXValues = new float[] { -2.5f, 0f, 2.5f };
        float randX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        nextTconeSpawn.x = randX;


        float[] possibleZValues = new float[] { -10f, -6.5f, -5f, 3f, 0f, 5f, 6.5f, 10f, -15f, 15f };
        float[] availableZValues = possibleZValues.Except(usedZPositions).ToArray();

        // Check if there are any available z positions left.
        if (availableZValues.Length == 0)
        {
            // All z positions have been used.
            usedZPositions.Clear();
            availableZValues = possibleZValues; // Use all possible z values again.
        }

        float randZ = availableZValues[Random.Range(0, availableZValues.Length)];

        // Add the newly used z position to the list.
        usedZPositions.Add(randZ);

        nextTconeSpawn.z = nextTconeSpawn.z + randZ;

        int randObstacle = Random.Range(0, 3);

        if (randObstacle == 0)
        {
            nextTconeSpawn.y = 0.427f;
            Instantiate(firstObj, nextTconeSpawn, firstObj.rotation);
        }
        else if (randObstacle == 1)
        {
            nextTconeSpawn.y = 0.04f;
            Instantiate(secondObj, nextTconeSpawn, secondObj.rotation);
        }
        else if (randObstacle == 2)
        {
            nextTconeSpawn.y = 0.35f;
            Instantiate(thirdObj, nextTconeSpawn, thirdObj.rotation);
        }

        

    }

    //IEnumerator decide()
    //{
    //    if (nextinvisispawn.z <= 150)
    //    {
    //        StartCoroutine(spawnInvisi());
    //        Debug.Log("abhi day k karo");
    //    }
    //    else 
    //    {
    //        StartCoroutine(NextspawnInvisi());
    //        Debug.Log("abhi night k karo");

    //    }

    //    yield return new WaitForSeconds(1);
    //}

    //IEnumerator decide()
    //{
    //    while (true)
    //    {
    //        if (nextinvisispawn.z <= 150)
    //        {
    //            StartCoroutine(spawnInvisi());
    //            Debug.Log("abhi day k karo");
    //        }
    //        else
    //        {
    //            StartCoroutine(NextspawnInvisi());
    //            Debug.Log("abhi night k karo");
    //        }

    //        yield return new WaitForSeconds(1);
    //    }
    //}

}
