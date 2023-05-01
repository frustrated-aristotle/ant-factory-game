using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
   public bool hasRight, hasLeft, hasDown, hasUp;
   public string way;
   public  Vector3 instantiationPos;
   public  Vector3 targetPos;
   private Vector3 pos;
   
   public Sprite spriteWithArrow;
   public Sprite currentSprite;
   public List<Sprite> placeHolderSprites = new List<Sprite>();
   
   public  GameObject rightBottom, leftBottom, rightUp, leftUp;

   private List<GameObject> neighbours = new List<GameObject>();

   private BuyAndPlaceBuildables buyAndPlaceBuildables;
   private void Awake()
   {
      instantiationPos = transform.GetChild(0).GetComponent<Transform>().position;
      targetPos = transform.GetChild(1).GetComponent<Transform>().position;
      currentSprite = spriteWithArrow;
      }

   private void Start()
   {
      GetNeighbours();
      buyAndPlaceBuildables = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
      CheckWay();
   }

   private void GetNeighbours()
   {
      MainTileScript mainTileScript = GetComponent<MainTileScript>();
      neighbours = mainTileScript.neighbours;
   }
   private void OnMouseOver()
   {
      if (Input.GetMouseButtonDown(1))
      {
         buyAndPlaceBuildables.PlaceNormalTile(this.gameObject);
      }
   }
   public void CheckWay()
   {
      float z = transform.rotation.z;
      if (z < 0)
      {
         way = "DownUp";
      }
      else if (z == 1 )
      {
         way = "LeftRight";
      }
      else if (z > 0 && z < 1 )
      {
         way = "DownUp";
      }
      else
      {
         way = "LeftRight";
      }
   }
}
