using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject home;
    public int type, degree;
    public bool hasRight, hasUp, hasLeft, hasDown;
    private bool isUpdatedAtCreateTime;

    //public Path rightPath, leftPath, upPath, downPath;
    public GameStateSO gameState;
    
    public List<GameObject> adjRoads = new List<GameObject>();
    public Sprite horizontalSecondary, verticalSecondary, rightBottom, leftBottom, rightUp, leftUp;
    public Sprite thirdUp, thirdRight, thirdLeft, thirdBottom, fourWays;

    private PathCreationManager pathCreationManager;
    //We know the prior tiles index on their neighbours list.
    //We need to reach our neighbours neighbours list and assign this game object to what we have replaced.
    //! Check for the compability that comes from direction of the road. If the road is horizontal, it has not up or down.

    public bool IsOneOfThirds()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        if (sprite == thirdUp || sprite == thirdBottom || sprite == thirdLeft || sprite == thirdRight)
        {
            return true;
        }
        else
            return false;
    }
    private void Start()
    {
        pathCreationManager = GameObject.FindObjectOfType<PathCreationManager>();
        foreach (GameObject neighbour in GetComponent<MainTileScript>().neighbours)
        {
            //neighbour.GetComponent<MainTileScript>().CheckRoads();
        }

        if (GetComponent<MainTileScript>().isItABuilding == false)
        {
            
        }

        Upgrade();
    }

    public void Upgrade()
    {
        switch (type)
        {
            case 0:
                UpgradeHorizontal();
                break;
            case 1:
                UpgradeVertical();
                break;
        }
    }

    private void UpgradeHorizontal()
    {
        if (hasRight && hasLeft && !hasUp && !hasDown)
        {
            UpgradeIt(horizontalSecondary);
        }
        else if (hasRight && hasUp && !hasLeft && !hasDown)
        {
            if (GetComponent<SpriteRenderer>().sprite != thirdUp)
            {
                UpgradeIt(rightBottom);
            }
        }
        else if (hasRight && hasDown && !hasLeft && !hasUp)
        {
            UpgradeIt(rightUp);
        }
        else if (hasLeft && hasUp && !hasDown && !hasRight)
        {
            if (GetComponent<SpriteRenderer>().sprite != thirdUp)
            {
                UpgradeIt(leftBottom);
            }
        }
        else if (hasLeft && hasDown && !hasUp && !hasRight)
        {
            UpgradeIt(leftUp);
        }
        else if ((hasRight && hasLeft && hasUp && !hasDown) || (hasUp && !hasLeft && !hasDown && !hasRight))
        {
            UpgradeIt(thirdUp);
            degree = 3;
        }
        else if ((hasRight && hasLeft && hasDown && !hasUp) || (hasDown && !hasLeft && !hasUp && !hasRight))
        {
            UpgradeIt(thirdBottom);
            degree = 3;
        }
        else if (hasRight && hasUp && hasDown && ! hasLeft)
        {
            UpgradeIt(thirdRight);
            degree = 3;
        }
        else if (hasLeft && hasUp && hasDown && !hasRight)
        {
            UpgradeIt(thirdLeft);
            degree = 3;
        }
        else if ((hasLeft && hasUp && hasDown && hasRight) || IsOneOfThirds())
        {
            UpgradeIt(fourWays);
            degree = 4;
        } 
        else
        {
        }
    }
    private void UpgradeVertical()
     {
         if (hasUp && hasDown && !hasRight && !hasLeft)
         {
             UpgradeIt(verticalSecondary);
         }
         else if ((hasRight && hasUp && !hasLeft && !hasDown))
         {
             UpgradeIt(rightBottom);
         }
         else if (hasRight && hasDown && !hasLeft && !hasUp)
         {
             UpgradeIt(rightUp);
         }
         else if (hasLeft && hasUp && !hasDown && !hasRight)
         {
             UpgradeIt(leftBottom);
         }
         else if (hasLeft && hasDown && !hasUp && !hasUp)
         {
             UpgradeIt(leftUp);
         }
         else if (hasRight && hasLeft && hasUp && !hasDown)
         {
             UpgradeIt(thirdUp);
         }
         else if (hasRight && hasLeft && hasDown && !hasUp)
         {
             UpgradeIt(thirdBottom);
         }
         else if ((hasRight && hasUp && hasDown && ! hasLeft) || (!hasDown && !hasLeft && !hasUp && hasRight))
         {
            
             if (GetComponent<SpriteRenderer>().sprite != thirdRight)
             {
                 UpgradeIt(thirdRight);
             }
         }
         else if ((hasLeft && hasUp && hasDown && !hasRight) || (!hasDown && hasLeft && !hasUp && !hasRight))
         {
             if (GetComponent<SpriteRenderer>().sprite != thirdLeft)
             {
                 UpgradeIt(thirdLeft);
             }
         }
         else if ((hasLeft && hasUp && hasDown && hasRight) || IsOneOfThirds())
         {
             UpgradeIt(fourWays);
         }
     }
    private void UpgradeIt(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    //This will probably not used
    public bool IsNeighbourSuitableByItsType(Road adjacentRoad) 
    {
        switch (type)
        {
            case 0:
                if (adjacentRoad.type == 0  && transform.position.y != adjacentRoad.transform.position.y)
                { 
                    return false;
                }
                break;
            case 1:
                if (adjacentRoad.type == 1  && transform.position.x != adjacentRoad.transform.position.x)
                {
                    return false;
                }
                break;
        }

        return true;
    }

    //This wont be used
    private void OnMouseDown()
    {
        //if (gameState.currentGameState == "Path Creation")
        {
            Debug.Log("Works");
            pathCreationManager.AddTheRoadToHomeAsWayPoint(this.transform);
        }
    }
}