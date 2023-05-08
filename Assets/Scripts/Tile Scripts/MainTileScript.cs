 using System.Collections.Generic;
 using Building_Scripts;
 using UnityEngine;
 using static GameStateManager;

 [RequireComponent(typeof(MouseMovementPlaceHolder))]
 public class MainTileScript : MonoBehaviour
{
    public  bool isItABuilding;
    public  bool isItFertile; 
    
    public GameObject emptyTile;
    public List<Transform> path = new List<Transform>();

    private BuyAndPlaceBuildables buyAndPlaceBuildables;
    private BuildingUIScript buildingUI;
    
    //States
    private GameStateManager stateManager;
    
    //0 = right 1 = left 2= up 3=bot
    public List<GameObject> neighbours = new List<GameObject>();
    //public List<ConveyorBelt> adjacentConveyorBelts = new List<ConveyorBelt>();
    //!Done
  //public List<GameObject> adjacentRoads = new List<GameObject>();
    private void Start()
    {
        stateManager = GameObject.FindObjectOfType<GameStateManager>();
        buyAndPlaceBuildables = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
        buildingUI = GameObject.FindObjectOfType<BuildingUIScript>();
    }
    #region  Purchase
    private void OnMouseDown()
    {
        GameObject buildableToPlace = stateManager.BuildableToPlace;
        if (stateManager.AreStatesTheSame(States.PURCHASE) && !buildingUI.CanMouseClick())
        //! If the game state is buying, we can do proceed.
        {
            if (buildableToPlace != null && !buildableToPlace.GetComponent<MainBuildingScript>())
            {
                buyAndPlaceBuildables.Buy(this.gameObject, buildableToPlace, 1);
            }
            else if (buildableToPlace != null && buildableToPlace.GetComponent<MainBuildingScript>() && isItFertile) 
            {
                buyAndPlaceBuildables.Buy(this.gameObject, buildableToPlace, 1);
            }
        }
        else if (stateManager.AreStatesTheSame(States.BULLDOZE) && GetComponent<ConveyorBelt>())
        {
            buyAndPlaceBuildables.Buy(gameObject, emptyTile, 1);
        }
    }
    #endregion
}
