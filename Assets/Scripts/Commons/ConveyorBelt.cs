using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
   public bool hasRight, hasLeft, hasDown, hasUp;
   public Vector3 instantiationPos;
   public Vector3 targetPos;
   private Vector3 pos; 
   public GameObject rightBottom, leftBottom, rightUp, leftUp;
   private void Awake()
   {
      instantiationPos = transform.GetChild(0).GetComponent<Transform>().position;
      targetPos = transform.GetChild(1).GetComponent<Transform>().position;
   }

   private void Start()
   {
      pos = transform.position;
      MainTileScript mainTileScript = GetComponent<MainTileScript>();
      List<GameObject> neighbours = mainTileScript.neighbours;
      
      foreach (GameObject neighbour in neighbours)
      {
         neighbour.GetComponent<MainTileScript>().CheckConveyors();
      }
   }

   public void Upgrade()
   {
      //there must be at least 4 condition for 4 case.
      if (hasRight && hasDown)
      {
         ChangeConveyorBelt(rightUp);
         //RightUp
      }
      else if (hasRight && hasUp)
      {
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
      Debug.Log("Inst");
      Instantiate(conveyorGameObject, pos, quaternion.identity);
      Destroy(this.gameObject);
   }
}
