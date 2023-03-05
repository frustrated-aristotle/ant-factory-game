using System;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public RoadScriptableObject roadScriptableObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            roadScriptableObject.ChangeRoad();
    }
}
