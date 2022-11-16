using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AirplaneScriptableObject", menuName = "ScriptableObjects/Airplane")]
public class AirplaneScriptableObject : ScriptableObject
{
    [SerializeField] private string airplaneType = "Fokker F.XXXVI";
    [SerializeField] private string airplaneCompany = "KLM";


}
