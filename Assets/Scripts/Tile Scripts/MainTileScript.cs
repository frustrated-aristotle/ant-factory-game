 using System.Collections.Generic;
 using Building_Scripts;
 using UnityEngine;

 public class MainTileScript : MonoBehaviour
{
    public  bool isItABuilding;
    public  bool isItFertile; 
    
    public GameObject emptyTile;
    public List<Transform> path = new List<Transform>();

    private BuyAndPlaceBuildables buyAndPlaceBuildables;
    private BuildingUIScript buildingUI;
    
    [SerializeField]
    private GameStateSO gameState;

    //0 = right 1 = left 2= up 3=bot
    public List<GameObject> neighbours = new List<GameObject>();
    //public List<ConveyorBelt> adjacentConveyorBelts = new List<ConveyorBelt>();
    //!Done
  //public List<GameObject> adjacentRoads = new List<GameObject>();
    private void Start()
    {
        buyAndPlaceBuildables = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
        buildingUI = GameObject.FindObjectOfType<BuildingUIScript>();
    }
    #region  Purchase
    private void OnMouseDown()
    {
        //! If the game state is buying, we can do proceed.
        if(gameState.IsTheStatePurchase() && !buildingUI.CanMouseClick())
        {
            if (gameState.toPlace != null && !gameState.toPlace.GetComponent<MainBuildingScript>())
            {
                buyAndPlaceBuildables.Buy(this.gameObject, gameState.toPlace);
            }
            else if (gameState.toPlace != null && gameState.toPlace.GetComponent<MainBuildingScript>() && isItFertile) 
            {
                buyAndPlaceBuildables.Buy(this.gameObject, gameState.toPlace);
            }
        }
        else if (gameState.currentGameState == gameState.bulldoze && GetComponent<ConveyorBelt>())
        {
            buyAndPlaceBuildables.Buy(gameObject, emptyTile);
            Debug.Log("Its else if and it seems not suitable");
        }
    }
    #endregion
}
