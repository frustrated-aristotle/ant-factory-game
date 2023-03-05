using System;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
   public bool hasRight, hasLeft, hasDown, hasUp;

   private void Start()
   {
      MainTileScript mainTileScript = GetComponent<MainTileScript>();
      List<GameObject> neighbours = mainTileScript.neighbours;
      foreach (GameObject neighbour in neighbours)
      {
         neighbour.GetComponent<MainTileScript>().CheckConveyors();
      }
   }
   /*public bool IsNeighbourSuitableByItsType(ConveyorBelt adjConveyor)
   {
      
   }*/
}
