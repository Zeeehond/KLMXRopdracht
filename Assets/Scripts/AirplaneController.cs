using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private AirplaneScriptableObject airplaneScriptableObject;
    [SerializeField] private float wanderRadius = 5;
    [SerializeField] private float standbyTimer = 0.5f;

    private Transform target;
    private NavMeshAgent airplaneAgent;
    private float timer;

    void Start()
    {
        airplaneAgent = GetComponent<NavMeshAgent>();
        timer = airplaneScriptableObject.standbyTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= airplaneScriptableObject.standbyTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, airplaneScriptableObject.wanderRadius, -1);
            airplaneAgent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

}
