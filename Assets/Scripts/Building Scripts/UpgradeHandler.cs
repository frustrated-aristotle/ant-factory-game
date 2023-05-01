using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    public int level = 1;
    public GameObject leftTop, leftBottom, rightTop, rightBottom;
    private BuyAndPlaceBuildables buy;
    

    private NeighbourFinder currentTileNeighbourFinder;
    //private MainTileScript currentMainTileScript;
        
    public void Upgrade(NeighbourFinder currentTile)
    {
        currentTileNeighbourFinder = currentTile;
        buy = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
        switch (level)
        {
            case 1:
                SecondLevelCheck();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
        //We need to     
    }

    public void SecondLevelCheck()
    {
        // 0 = LEFT |||| 1 = RIGHT |||| 2 = UP |||| 3 = DOWN
       // bool one = currentTileNeighbourFinder.hasAdjacent[2];
        //bool two = currentTileNeighbourFinder.hasAdjacent[0];
        
        
        if (currentTileNeighbourFinder.hasAdjacent[0] && currentTileNeighbourFinder.hasAdjacent[2])
        {
            //Check Direction
            Debug.Log("leftbottom if");
            if(CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[0], "LeftRight") && CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[2], "DownUp"))
                UpgradeTile(leftBottom);
        }
        else if (currentTileNeighbourFinder.hasAdjacent[1] && currentTileNeighbourFinder.hasAdjacent[2])
        {
            if(CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[1], "LeftRight") && CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[2], "DownUp"))
                UpgradeTile(rightBottom);
        }
        else if (currentTileNeighbourFinder.hasAdjacent[0] && currentTileNeighbourFinder.hasAdjacent[3])
        {
            if(CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[0], "LeftRight") && CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[3], "DownUp"))
                UpgradeTile(leftTop);
        }
        else if (currentTileNeighbourFinder.hasAdjacent[1] && currentTileNeighbourFinder.hasAdjacent[3])
        {
            Debug.Log("First " + this.name);
            if(CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[1], "LeftRight") && CheckConveyorsDirections(currentTileNeighbourFinder.neighbours[3], "DownUp"))
                 UpgradeTile(rightTop);
        }
        
    }

    private void UpgradeTile(GameObject toUpgrade)
    {
        buy.Buy(this.gameObject, toUpgrade,level+1);
    }

    private bool CheckConveyorsDirections(GameObject conveyor, string direction)
    {
        ConveyorBelt _conveyor = conveyor.GetComponent<ConveyorBelt>();
        Debug.Log("Second " + this.name);

        if (conveyor.GetComponent<UpgradeHandler>().level == 1)
        {
            Debug.Log("Third " + this.name);
            _conveyor.CheckWay();
        }
        if (_conveyor.way == direction)
        {
            return true;
        }
        return false;
    }
}
