using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int hangarNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        AssignHangarNumbers();
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

}
