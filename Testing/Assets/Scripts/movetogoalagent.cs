using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;
using UnityEngine.XR;
using JetBrains.Annotations;

public class movetogoalagent : Agent{

    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    /*[SerializeField] private GameObject stonePrefab;
    [SerializeField] private GameObject satellitePrefab;
    [SerializeField] private GameObject rocketPrefab;
    public Transform spawnPoint;
    private Transform stoneTransform; // Transform of the instantiated stone object
    private Transform satelliteTransform; // Transform of the instantiated satellite object
    private Transform rocketTransform; */




    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, -2, 3);
        //-2 x, -2, 37
        /*float[] possibleXValues = new float[] { -2.3f, 0.28f, 2.78f };
        float randstoneX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        float randsatX = possibleXValues[Random.Range(0, possibleXValues.Length)];
        float randrocketX = possibleXValues[Random.Range(0, possibleXValues.Length)];

        float nextstone = randstoneX;
        float nextsat = randsatX;
        float nextrocket = randrocketX;


        int randz = Random.Range(11, 38);
        int randzroc = Random.Range(11, 38);
        int randzsat = Random.Range(11, 38);

        Vector3 stoneSpawnPos = new Vector3(randstoneX, -2.1f, randz);
        Vector3 satSpawnPos = new Vector3(randsatX, -2.1f, randzroc);
        Vector3 rocketSpawnPos = new Vector3(randrocketX, -2.1f, randzsat);

        GameObject stoneInstance = Instantiate(stonePrefab, stoneSpawnPos, Quaternion.identity, spawnPoint);
        GameObject satInstance = Instantiate(satellitePrefab, satSpawnPos, Quaternion.identity, spawnPoint);
        GameObject rocketInstance = Instantiate(rocketPrefab, rocketSpawnPos, Quaternion.identity, spawnPoint);

        stoneTransform = stoneInstance.transform;
        satelliteTransform = satInstance.transform;
        rocketTransform = rocketInstance.transform;

        stoneTransform.localPosition = new Vector3 (nextstone, -2.1f, randz);
        satelliteTransform.localPosition = new Vector3(nextsat, -2.1f, randzroc);
        rocketTransform.localPosition = new Vector3(nextrocket, -2.1f, randzsat); */
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
        /* sensor.AddObservation(stoneTransform.localPosition);
        sensor.AddObservation(satelliteTransform.localPosition);
        sensor.AddObservation(rocketTransform.localPosition); */


    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];

        transform.localPosition += new Vector3(moveX, 0, 8) * Time.deltaTime * 6f;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(+1f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }

        if (other.TryGetComponent<wall>(out wall Wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }

    }

}
