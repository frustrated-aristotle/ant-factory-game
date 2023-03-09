using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
   public bool hasRight, hasLeft, hasDown, hasUp;
   
   public  Vector3 instantiationPos;
   public  Vector3 targetPos;
   private Vector3 pos; 
   
   public  GameObject rightBottom, leftBottom, rightUp, leftUp;

   private List<GameObject> neighbours = new List<GameObject>();

   private BuyAndPlaceBuildables buyAndPlaceBuildables;
   private void Awake()
   {
      //instantiationPos = transform.GetChild(0).GetComponent<Transform>().position;
      //targetPos = transform.GetChild(1).GetComponent<Transform>().position;
   }

   private void Start()
   {
      MainTileScript mainTileScript = GetComponent<MainTileScript>();
      neighbours = mainTileScript.neighbours;
      buyAndPlaceBuildables = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
      foreach (GameObject neighbour in neighbours)
      {
         if (neighbour != null)
         {
            neighbour.GetComponent<MainTileScript>().CheckConveyors();
         }

      }
      GetComponent<MainTileScript>().CheckConveyors();
      Upgrade();
   }

   private void Upgrade()
   {
      //there must be at least 4 condition for 4 case.
      if (hasRight && hasDown)
      {
         ChangeConveyorBelt(rightUp);
         //RightUp
      }
      else if (hasRight && hasUp)
      {
         Debug.Log(this);
         ChangeConveyorBelt(rightBottom);
         //RightBottom
      }
      else if (hasLeft && hasDown)
      {
         ChangeConveyorBelt(leftUp);
         //LeftUp
      }
      else if (hasLeft && hasUp)
      {
         ChangeConveyorBelt(leftBottom);
         //LeftDown
      }

   }

   private void ChangeConveyorBelt(GameObject conveyorGameObject)
   {
      pos = transform.position;
      //buyAndPlaceBuildables.Buy(this.gameObject, conveyorGameObject);
      
      GiveNeighbours(conveyorGameObject);
      Destroy(this.gameObject);
   }

   private void GiveNeighbours(GameObject conveyorGameObject)
   {

      GameObject upgradedConveyor = conveyorGameObject;
      
      MainTileScript upgradedConveyorMainTileScript = upgradedConveyor.GetComponent<MainTileScript>();
      
      upgradedConveyorMainTileScript.adjacentConveyorBelts = GetComponent<MainTileScript>().adjacentConveyorBelts;
      upgradedConveyorMainTileScript.neighbours = neighbours;
      
      upgradedConveyorMainTileScript.CheckConveyors();
      
      GameObject upgradedConveyorI = Instantiate(upgradedConveyor, pos, quaternion.identity);
      
      
      Debug.Log("HasLeft: " + upgradedConveyorI.GetComponent<ConveyorBelt>().hasLeft);
      //upgradedConveyorMainTileScript.CheckConveyors();
      Debug.Log("HasLeftII: " + upgradedConveyorI.GetComponent<ConveyorBelt>().hasLeft);
      
      ReplaceItselfWithPriorForNeighbours(upgradedConveyorI);

   }

   private void ReplaceItselfWithPriorForNeighbours(GameObject upgradedConveyor)
   {
      //In upgrade phase, prior tile will be destroyed. 
      //By mean of that, neighbours of prior tile will have a null referenced neighbour in place of this prior tile.
      //We need to find the index of our prior tile in their neighbours. And replace it with our new upgraded tile. 

      foreach (GameObject neighbour in neighbours)
      {
         int indexOfNeighboursArray = neighbour.GetComponent<MainTileScript>().neighbours.IndexOf(this.gameObject);
         neighbour.GetComponent<MainTileScript>().neighbours[indexOfNeighboursArray] = upgradedConveyor;
      }
   }
}
