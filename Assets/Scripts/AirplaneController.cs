using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private AirplaneScriptableObject airplaneScriptableObject;

    private Transform target;
    private NavMeshAgent airplaneAgent;
    private float timer;
    public int airplaneNumber;

    void Start()
    {
        airplaneScriptableObject.parked = false;
        airplaneAgent = GetComponent<NavMeshAgent>();
        timer = airplaneScriptableObject.standbyTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (!airplaneScriptableObject.parked)
        {
            if (timer >= airplaneScriptableObject.standbyTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, airplaneScriptableObject.wanderRadius, -1);
                airplaneAgent.SetDestination(newPos);
                timer = 0;
            }
        }

        if(Input.GetKeyDown("space"))
        {
            MoveToHangar();
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

    void MoveToHangar()
    {
        airplaneScriptableObject.parked = true;

        GameObject[] hangarObjects = GameObject.FindGameObjectsWithTag("Hangar");
        foreach (GameObject hangar in hangarObjects)
        {
            int hangarNumber = int.Parse(hangar.transform.Find("HangarNumber").GetComponent<TextMeshPro>().text);
            if (hangarNumber == airplaneNumber)
            {
                airplaneAgent.SetDestination(hangar.transform.position);
                break;
            }
        }
    }
}
