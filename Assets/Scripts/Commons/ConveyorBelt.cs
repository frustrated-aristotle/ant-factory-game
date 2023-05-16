using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Building_Scripts;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
   public enum Direction
   {
      LEFT,
      UP,
      RIGHT,
      DOWN,
   }

   [SerializeField] private FactoryResourcesSO fr;
   Animator anim;
   public Direction direction;
   public Direction inheretedDirection;
   public  Vector3 instantiationPos;
   public  Vector3 targetPos;
   private Vector3 pos;
   
   public Sprite spriteWithArrow;
   public Sprite currentSprite;
   public List<Sprite> placeHolderSprites = new List<Sprite>();
   
   private List<GameObject> neighbours = new List<GameObject>();

   private BuyAndPlaceBuildables buyAndPlaceBuildables;

   public RuntimeAnimatorController animatorController;

   public int cost;
   
   //Directions
   
   private void Awake()
   {
      buyAndPlaceBuildables = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();

      if (!GetComponent<MainBuildingScript>())
      {
         instantiationPos = transform.GetChild(0).GetComponent<Transform>().position;
         targetPos = transform.GetChild(1).GetComponent<Transform>().position;
      }
      //currentSprite = spriteWithArrow;
      anim = GetComponent<Animator>();
      if (GetComponent<UpgradeHandler>().level == 2)
      {
         anim.SetInteger("conveyorDirection", 5);
      }
   }
   
   private void Start()
   {
      Debug.Log("b");
      GetNeighbours();
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
         buyAndPlaceBuildables.Buy(this.gameObject, buyAndPlaceBuildables.defaultTile, 0, 0);
         fr.money += cost;
         //buyAndPlaceBuildables.PlaceNormalTile(this.gameObject);
      }
   }

   public void EnableDirections()
   {
      anim.SetBool("isDirectionOverlayOpened", true);     
      if (GetComponent<UpgradeHandler>().level == 2)
      {
         anim.SetInteger("conveyorDirection",(int)inheretedDirection);
         //anim.runtimeAnimatorController = animatorController;
         //anim.runtimeAnimatorController = animHolder.animControllers
      }
   }

   public void UnableDirections()
   {
      anim.SetBool("isDirectionOverlayOpened", false);
      if (GetComponent<UpgradeHandler>().level == 2)
      {
         anim.SetInteger("conveyorDirection" , 5);
      }
   }
   
   
}
