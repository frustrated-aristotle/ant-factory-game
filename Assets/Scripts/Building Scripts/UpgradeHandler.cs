using System.Collections.Generic;
using Building_Scripts;
using UnityEngine;
using Direction = ConveyorBelt.Direction;

public class UpgradeHandler : MonoBehaviour
{
    public int level = 1;
    
    private BuyAndPlaceBuildables buy;
    private RequiredGameManagerScript conveyors;

    private NeighbourFinder currentTileNeighbourFinder;
    //private MainTileScript currentMainTileScript;
    private List<GameObject> neighbours = new List<GameObject>(4);

  
    public void Upgrade(NeighbourFinder currentTile)
    {
        neighbours = currentTile.neighbours;
        currentTileNeighbourFinder = currentTile;
        buy = GameObject.FindObjectOfType<BuyAndPlaceBuildables>();
        if (!GetComponent<MainBuildingScript>())
        {
            SecondLevelCheck();
        }
    }

    public void SecondLevelCheck()
    {
        conveyors = GameObject.FindObjectOfType<RequiredGameManagerScript>();
        bool adj0 = currentTileNeighbourFinder.hasAdjacent[0];
        bool adj1 = currentTileNeighbourFinder.hasAdjacent[1];
        bool adj2 = currentTileNeighbourFinder.hasAdjacent[2];
        bool adj3 = currentTileNeighbourFinder.hasAdjacent[3];

        List<GameObject> tempNeighbours = new List<GameObject>(2);
        // 0 = LEFT |||| 1 = RIGHT |||| 2 = UP |||| 3 = DOWN
        
        
        
       // bool one = currentTileNeighbourFinder.hasAdjacent[2];
        //bool two = currentTileNeighbourFinder.hasAdjacent[0];
        //RU
        if ( adj0 && adj2)
        {        
            //
            /*
            if (neighbours[0].GetComponent<MainBuildingScript>())
            {
                Direction dir1 = Direction.LEFT;
                UpgradeTileIfDirectionsAreOkay(dir1, neighbours[2].GetComponent<ConveyorBelt>().direction, Direction.RIGHT, Direction.UP, Direction.LEFT, Direction.DOWN, conveyors.rU, conveyors.dL);
            }
            else if (neighbours[2].GetComponent<MainBuildingScript>())
            {
                Direction dir2 = Direction.DOWN;
                UpgradeTileIfDirectionsAreOkay(neighbours[0].GetComponent<ConveyorBelt>().direction, dir2, Direction.RIGHT, Direction.UP, Direction.LEFT,
            Direction.DOWN, conveyors.rU, conveyors.dL);
            }
             */
            if (AreLevelsTwo(neighbours[0], neighbours[2]))
            {
                Debug.Log("1");
                UpgradeTileIfDirectionsAreOkay(neighbours[0], neighbours[2], Direction.RIGHT, Direction.UP, Direction.LEFT,
                    Direction.DOWN, conveyors.rU, conveyors.dL,tempNeighbours);
            }
            else
            {
                UpgradeTileIfDirectionsAreOkay(neighbours[0], neighbours[2], Direction.RIGHT, Direction.UP, Direction.LEFT,
                Direction.DOWN, conveyors.rU, conveyors.dL);
                
            }

           
        }
        else if (adj1 && adj2)
        {
            if (AreLevelsTwo(neighbours[1], neighbours[2]))
            {
                UpgradeTileIfDirectionsAreOkay(neighbours[1], neighbours[2], Direction.RIGHT, Direction.DOWN, Direction.LEFT, Direction.UP, conveyors.dR, conveyors.lU, tempNeighbours);
            }
            else
            {
                UpgradeTileIfDirectionsAreOkay(neighbours[1], neighbours[2], Direction.RIGHT, Direction.DOWN, Direction.LEFT, Direction.UP, conveyors.dR, conveyors.lU);
            }
        }
        else if (adj0 && adj3)
        {
            Debug.Log("03");
            if (AreLevelsTwo(neighbours[0], neighbours[3]))
            {
                Debug.Log("03.1");
                UpgradeTileIfDirectionsAreOkay(neighbours[0], neighbours[3], Direction.LEFT, Direction.UP, Direction.RIGHT, Direction.DOWN, conveyors.uL, conveyors.rD, tempNeighbours);
            }
            else
            {
                Debug.Log("03.2");
                UpgradeTileIfDirectionsAreOkay(neighbours[0], neighbours[3], Direction.LEFT, Direction.UP, Direction.RIGHT, Direction.DOWN, conveyors.uL, conveyors.rD);
            }
        }
        else if (adj1 && adj3)
        {
            Debug.Log("13");
            if (AreLevelsTwo(neighbours[1], neighbours[3]))
            {
                Debug.Log("132");

                UpgradeTileIfDirectionsAreOkay(neighbours[1], neighbours[3], Direction.LEFT, Direction.DOWN , Direction.RIGHT, Direction.UP, conveyors.lD, conveyors.uR,tempNeighbours);
            }
            else
            {
                Debug.Log("133");
                UpgradeTileIfDirectionsAreOkay(neighbours[1], neighbours[3], Direction.LEFT, Direction.DOWN , Direction.RIGHT, Direction.UP, conveyors.lD, conveyors.uR);
            }
        }
    }

    private void UpgradeTileIfDirectionsAreOkay(GameObject belt1, GameObject belt2, Direction dir1, Direction dir2, Direction dir3, Direction dir4, GameObject first, GameObject second)
    {
        ConveyorBelt firstBelt = belt1.GetComponent<ConveyorBelt>();
        ConveyorBelt secondBelt = belt2.GetComponent<ConveyorBelt>();
        
        bool belt1Check = firstBelt.direction == dir1;
        bool belt2Check = secondBelt.direction == dir2;
        bool belt12Check = firstBelt.direction == dir3;
        bool belt22Check = secondBelt.direction == dir4;

        bool isFirstCombinationOkay = belt1Check && belt2Check;
        bool isSecondCombinationOkay = belt12Check && belt22Check;
        
        if (isFirstCombinationOkay)
        {
            UpgradeTile(first);
        }
        else if (isSecondCombinationOkay)
        {
            UpgradeTile(second);
        }
    }

    private void UpgradeTileIfDirectionsAreOkay(GameObject n1, GameObject n2, Direction dir1, Direction dir2, Direction dir3, Direction dir4, GameObject first, GameObject second, List<GameObject>tempNeighbours)
    {
        Debug.Log("3");

        tempNeighbours.Add(n1);
        tempNeighbours.Add(n2);

        List<Direction> dirs1 = new List<Direction>(2);
        dirs1.Add(dir1);
        dirs1.Add(dir2);
        
        List<Direction> dirs2 = new List<Direction>(2);
        dirs2.Add(dir3);
        dirs2.Add(dir4);

        
        // ReSharper disable once NotAccessedVariable
        int indexOfSecondLevel = 0;
        int indexOfNecessaryBelt = 0;
        foreach (GameObject neighbour in tempNeighbours)
        {
            if (neighbour.GetComponent<UpgradeHandler>().level == 2)
            {
                indexOfSecondLevel = tempNeighbours.IndexOf(neighbour);
            }
        }

        indexOfNecessaryBelt = (indexOfSecondLevel == 0) ? 1 : 0;
        
        bool beltCheck = tempNeighbours[indexOfNecessaryBelt].GetComponent<ConveyorBelt>().direction ==
                         dirs1[indexOfNecessaryBelt];
        bool beltCheck2 = tempNeighbours[indexOfNecessaryBelt].GetComponent<ConveyorBelt>().direction ==
                          dirs2[indexOfNecessaryBelt];

        if (beltCheck)
        {
            UpgradeTile(first);
        }
        else if (beltCheck2)
        {
            UpgradeTile(second);
        }
        
        


    }

    private void UpgradeTileIfDirectionsAreOkay(Direction dir1, Direction dir2, Direction dirCheck1, Direction dirCheck2, Direction dirCheck3, Direction dirCheck4, GameObject first, GameObject second)
    {
        bool check1 = dir1 == dirCheck1;
        bool check2 = dir2 == dirCheck2;
        bool check3 = dir1 == dirCheck3;
        bool check4 = dir2 == dirCheck4;

        bool isFirstCombOkay = check1 && check2;
        bool isSecondCombOkay = check3 && check4;

        if (isFirstCombOkay)
        {
            UpgradeTile(first);
        }
        else if (isSecondCombOkay)
        {
            UpgradeTile(second);
        }
    }
    private void UpgradeTile(GameObject toUpgrade)
    {
        buy.Buy(this.gameObject, toUpgrade,level+1);
    }

    private bool AreLevelsTwo(GameObject first, GameObject second)
    {
        UpgradeHandler firstUpgrade = first.GetComponent<UpgradeHandler>();
        UpgradeHandler secondUpgrade = second.GetComponent<UpgradeHandler>();

        bool firstBool = firstUpgrade.level == 2;
        bool secondBool = secondUpgrade.level == 2;

        bool returnValue = firstBool || secondBool;
        
        return returnValue;
    }
}
