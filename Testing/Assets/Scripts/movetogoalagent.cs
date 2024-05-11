using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;
using UnityEngine.XR;
using JetBrains.Annotations;

public class movetogoalagent : Agent
{

    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    [SerializeField] private Transform obstacle1;
    [SerializeField] private Transform obstacle2;
    [SerializeField] private Transform obstacle3;
    [SerializeField] private Transform obstacle4;
    [SerializeField] private Transform obstacle5;
    [SerializeField] private Transform obstacle6;



    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, -2, 3);
        //-2 x, -2, 37
        
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
        RandomizeObstaclePosition(obstacle1);
        RandomizeObstaclePosition(obstacle2);
        RandomizeObstaclePosition(obstacle3);
        RandomizeObstaclePosition(obstacle4);
        RandomizeObstaclePosition(obstacle5);
        RandomizeObstaclePosition(obstacle6);

    }

    private void RandomizeObstaclePosition(Transform obstacle)
    {
        // Randomize x-axis position from the provided choices
        float randomX = Random.Range(-2.3f, 2.78f);

        // Fixed y-axis and randomized z-axis position
        float randomZ = Random.Range(11f, 37f);

        // Set obstacle position
        obstacle.localPosition = new Vector3(randomX, 2f, randomZ);
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
