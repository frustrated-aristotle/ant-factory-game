using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] private int level = 1;
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
            UpgradeTile(leftBottom);
        }
        else if (currentTileNeighbourFinder.hasAdjacent[1] && currentTileNeighbourFinder.hasAdjacent[2])
        {
            //RIGHT UP
            UpgradeTile(rightBottom);
        }
        else if (currentTileNeighbourFinder.hasAdjacent[0] && currentTileNeighbourFinder.hasAdjacent[3])
        {
            UpgradeTile(leftTop);
        }
        else if (currentTileNeighbourFinder.hasAdjacent[1] && currentTileNeighbourFinder.hasAdjacent[3])
        {
            UpgradeTile(rightTop);
        }
        
    }

    public void ThirdLevelCheck()
    {
        
    }

    private void UpgradeTile(GameObject toUpgrade)
    {
        buy.Buy(this.gameObject, toUpgrade);
    }
}
