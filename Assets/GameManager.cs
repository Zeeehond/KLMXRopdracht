using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int hangarNumber = 1;
    private int airplaneNumber = 1;

    [SerializeField] private AirplaneScriptableObject airplaneScriptableObject;
    [SerializeField] private GameObject feedbackText;

    void Start()
    {
        AssignHangarNumbers();
        AssignAirplaneNumbers();
    }

    void AssignHangarNumbers()
    {
        GameObject[] hangarObjects = GameObject.FindGameObjectsWithTag("Hangar");
        foreach (GameObject hangar in hangarObjects)
        {
            TextMeshPro textMeshPro = hangar.transform.Find("HangarNumber").GetComponent<TextMeshPro>();
            textMeshPro.SetText("{0}", hangarNumber);
            hangarNumber++;
        }
    }
    void AssignAirplaneNumbers()
    {
        GameObject[] airplaneObjects = GameObject.FindGameObjectsWithTag("Airplane");
        foreach (GameObject airplane in airplaneObjects)
        {
            airplane.GetComponent<AirplaneController>().airplaneNumber = airplaneNumber;
            TextMeshPro textMeshPro = airplane.transform.Find("AirplaneNumber").GetComponent<TextMeshPro>();
            textMeshPro.SetText("{0}", airplaneNumber);
            airplaneNumber++;
        }
    }

    public void ParkAirplanes()
    {
        StartCoroutine(ParkingFeedbackCoroutine());
        GameObject[] airplaneObjects = GameObject.FindGameObjectsWithTag("Airplane");
        foreach (GameObject airplane in airplaneObjects)
        {
            airplane.GetComponent<AirplaneController>().MoveToHangar();
        }
    }

    IEnumerator ParkingFeedbackCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        feedbackText.SetActive(true);
    }

    public void EnableLights()
    {
        GameObject[] airplaneLightObjects = GameObject.FindGameObjectsWithTag("AirplaneLight");
        foreach (GameObject airplaneLight in airplaneLightObjects)
        {
            Light currentAirplaneLight = airplaneLight.GetComponent<Light>();
            currentAirplaneLight.enabled = true;
        }
    }

}
