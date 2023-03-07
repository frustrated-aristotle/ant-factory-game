using System;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
   public bool hasRight, hasLeft, hasDown, hasUp;
   public Vector3 instantiationPos;
   public Vector3 targetPos;
   private void Awake()
   {
      instantiationPos = transform.GetChild(0).GetComponent<Transform>().position;
      targetPos = transform.GetChild(1).GetComponent<Transform>().position;
   }

   private void Start()
   {
      MainTileScript mainTileScript = GetComponent<MainTileScript>();
      List<GameObject> neighbours = mainTileScript.neighbours;
      foreach (GameObject neighbour in neighbours)
      {
         neighbour.GetComponent<MainTileScript>().CheckConveyors();
      }
   }
}
