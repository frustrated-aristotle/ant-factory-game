 using System.Collections.Generic;
 using Building_Scripts;
 using UnityEngine;

 public class MainTileScript : MonoBehaviour
{
    public  bool isItABuilding;
    public  bool isItFertile; 
    public  bool hasNeighboursFound;

    
    public GameObject emptyTile;
    public List<Transform> path = new List<Transform>();

    private BuyAndPlaceBuildables buyAndPlaceBuildables;
    private TransporterManager transporterManager;
    private PathCreationManager pathCreationManager;
    private BuildingUIScript buildingUI;
    
    [SerializeField]
    private GameStateSO gameState;

    public RoadScriptableObject roadScriptableObject;

    
    #region Neighbour Handler
    
    //0 = right 1 = left 2= up 3=bot
    public List<GameObject> neighbours = new List<GameObject>();
    public List<ConveyorBelt> adjacentConveyorBelts = new List<ConveyorBelt>();
    //!Done
  //public List<GameObject> adjacentRoads = new List<GameObject>();
    private void Start()
    {
        buyAndPlaceBuildables = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
        transporterManager = GameObject.FindObjectOfType<TransporterManager>();
        pathCreationManager = GameObject.FindObjectOfType<PathCreationManager>();
        buildingUI = GameObject.FindObjectOfType<BuildingUIScript>();
    }
    private bool IsItAlreadyOnTheNeighboursList(GameObject col)
    {
        bool returnValue = neighbours.Contains(col) ? true : false;
        
        return returnValue;
    }

    private bool IsColValueGreater(float col, float your)
    {
        bool value = col > your ? true : false;
        return value;
    }

    private bool AreValuesEqual(float col, float your)
    {
        if (col == your) return true;
        else return false;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(!HasNeighboursFound())CheckColsPositionAndAssignItAsNeighbour(col);
    }
    private bool HasNeighboursFound()
    {
        if(hasNeighboursFound == false)
        {
            if (neighbours.Count == 4)
            {
                hasNeighboursFound = true;
                return hasNeighboursFound;
            }
            else
                return hasNeighboursFound = false;
        }
        else
        {
            return hasNeighboursFound;
        }
    }

    private void CheckColsPositionAndAssignItAsNeighbour(Collision2D col)
    {
        Vector3 colPos = col.transform.position;
        float colX = colPos.x;
        float colY = colPos.y;

        Vector3 thisPos = transform.position;
        float thisX = thisPos.x;
        float thisY = thisPos.y;
        if (col.transform.GetComponent<MainTileScript>())
        {
            if(!IsItAlreadyOnTheNeighboursList(col.gameObject))
            {
                //Right neighbour
                if (IsColValueGreater(colX,thisX ) && AreValuesEqual(colY, thisY))
                {
                    AddItToNeighbours(col.gameObject,0);
                }
                //Left neighbour
                else if (!IsColValueGreater(colX, thisX) && AreValuesEqual(colY, thisY))
                {
                    AddItToNeighbours(col.gameObject,1);
                }
                else if (IsColValueGreater(colY, thisY) && AreValuesEqual(colX,thisX))
                {
                    AddItToNeighbours(col.gameObject,2);
                }
                else if (!IsColValueGreater(colY,thisY) && AreValuesEqual(colX, thisX))
                    AddItToNeighbours(col.gameObject,3);
            }
        }

    }

    private void AddItToNeighbours(GameObject col, int neighbourIndex)
    {
        neighbours.Add(col);
    }

    public void CheckConveyors()
    {
        foreach (GameObject neighbour in neighbours)
        {
            if (neighbour.CompareTag("Conveyor") && !adjacentConveyorBelts.Contains(neighbour.GetComponent<ConveyorBelt>()))
            {
                adjacentConveyorBelts.Add(neighbour.GetComponent<ConveyorBelt>());
                CheckSides(neighbour.GetComponent<ConveyorBelt>());
                //We need to upgrade.
            }
        }
    }
    //!Done
    /*
    public void CheckRoads()
    {
        foreach (GameObject neighbour in neighbours)
        {
            if (neighbour.CompareTag("Road") && !adjacentRoads.Contains(neighbour))
            {
                adjacentRoads.Add(neighbour);
                if (GetComponent<Road>())
                {
                    CheckSides(neighbour);
                    GetComponent<Road>().Upgrade();
                }
            }
        }
    }*/
    //
    private void CheckSides(ConveyorBelt neighbourConveyor)
    {
        Vector3 conveyorPos = neighbourConveyor.transform.position;
        float conveyorX = conveyorPos.x;
        float conveyorY = conveyorPos.y;
        Vector3 position = this.transform.position;
        float x = position.x;
        float y = position.y;

        if (conveyorX > x && conveyorY == y)
        {
            Debug.Log("neighbourConveyor");
            //neighbourConveyor.hasRight = true;
            if (isItABuilding)
            {
                Debug.Log("Conveyor");
                GetComponent<Storage>().startingConveyor = neighbourConveyor;
            }

            if (GetComponent<ConveyorBelt>())
            {
                this.gameObject.GetComponent<ConveyorBelt>().hasRight = true;
            }

        }
        else if (conveyorX < x && conveyorY == y)
        {
            //neighbourConveyor.hasLeft = true;
            if (GetComponent<ConveyorBelt>())
                this.gameObject.GetComponent<ConveyorBelt>().hasLeft = true;
        }
        else if (conveyorY > y && conveyorX == x)
        {
           // neighbourConveyor.hasUp = true;
            if (GetComponent<ConveyorBelt>())
                this.gameObject.GetComponent<ConveyorBelt>().hasUp = true;
        }
        else if (conveyorY < y && conveyorX == x )
        {
           // neighbourConveyor.hasDown = true;
            if (GetComponent<ConveyorBelt>())
                this.gameObject.GetComponent<ConveyorBelt>().hasDown = true;
        }
    }
    /*private void CheckSides(GameObject conveyor)
    {
        Road conveyorComponent = GetComponent<Road>();
        Road conveyor = conveyor.GetComponent<Road>();
        if (conveyorX > x && conveyorY == y && conveyor.IsNeighbourSuitableByItsType(conveyor))
            this.gameObject.GetComponent<ConveyorBelt>().hasRight = true;
        if (conveyorX < x && conveyorY == y && conveyor.IsNeighbourSuitableByItsType(conveyor))
            this.gameObject.GetComponent<ConveyorBelt>().hasLeft = true;
        if (conveyorY > y && conveyorX == x && conveyor.IsNeighbourSuitableByItsType(conveyor))
            this.gameObject.GetComponent<ConveyorBelt>().hasUp = true;
        if (conveyorY < y &&
            conveyorX == x &&
            conveyort.IsNeighbourSuitableByItsType(conveyor))
        {
            this.gameObject.GetComponent<ConveyorBelt>().hasDown = true;
        }
    }*/
    
    #endregion

    #region  Purchase
    private void OnMouseDown()
    {
        //! If the game state is buying, we can do proceed.
        if(gameState.IsTheStatePurchase() && !buildingUI.CanMouseClick())
        {
            //There are lots of buildable to purchase. We will give the purchase method
            //via the gamestate because it can say which building our player wants to place
            if (gameState.toPlace != null && !gameState.toPlace.GetComponent<MainBuildingScript>())
            {
                //if the toPlace building has any mainBuilding zart zurt thing,
                //We need to check if the tile is suitable for it. Is it fertile?
                buyAndPlaceBuildables.Buy(this.gameObject, gameState.toPlace);
            }
            else if (gameState.toPlace != null && gameState.toPlace.GetComponent<MainBuildingScript>() && isItFertile) 
            {
                buyAndPlaceBuildables.Buy(this.gameObject, gameState.toPlace);
            }

            
            //the game must check if the player is trying to purchase a transporter. 
            //If the clicked tile is a building tile, the player wants to purchase a transporter.
            //The job is done in this script. It is TransporterManager's job now.
            /*
             * 
            if(isItABuilding)
            {
                if(transporterManager.home == null)
                    transporterManager.home = this.gameObject;
                else
                    transporterManager.destination = this.gameObject;

                if (transporterManager.home != null && transporterManager.destination != null)
                {
                    List<Transform> _path = transporterManager.home.GetComponent<MainTileScript>().path;
                    transporterManager.BuyAndPlaceTransporter(_path);
                    _path.Clear();
                }
            }else
             */ 
        }
        else if (gameState.currentGameState == gameState.bulldoze && GetComponent<ConveyorBelt>())
        {
            buyAndPlaceBuildables.Buy(gameObject, emptyTile);
            Debug.Log("Its else if and it seems not suitable");
        }
        /*else if (gameState.currentGameState == "Path Creation" && isItABuilding)
        {
            if (pathCreationManager.home == null)
            {
                pathCreationManager.home = this;
                pathCreationManager.AddTheTargetToTheFrontOfThePath(this.transform);
            }
            else if (pathCreationManager.target == null) pathCreationManager.target = this;
            else pathCreationManager.AddTheTargetToTheEndOfThePath(this.transform);

        }*/
    }
    #endregion
}
