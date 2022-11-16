using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AirplaneScriptableObject", menuName = "ScriptableObjects/Airplane")]
public class AirplaneScriptableObject : ScriptableObject
{
    public string airplaneType = "Fokker F.XXXVI";
    public string airplaneCompany = "KLM";
    public float wanderRadius = 5;
    public float standbyTimer = 0.5f;
    public bool parked = false;
}
