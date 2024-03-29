using System;
using System.Collections.Generic;
using Building_Scripts;
using UnityEngine;

//! If one of the adjacent conveyor's last point collides with other ones, higher level's points must be changed.
public class NeighbourFinder : MonoBehaviour
{
    private Vector2 orgPos, currentOriginPos, currentDirectionPos;
    private Vector2 x = new Vector2(0.6f, 0);
    private Vector2 y = new Vector2(0, 0.6f);
    
    private int neighbourCounter;

    public List<bool> hasAdjacent = new List<bool>()
    {
        false,
        false,
        false,
        false
    };

    private MainTileScript mainTileScript;
    
    public List<GameObject> neighbours = new List<GameObject>();
    //private List<ConveyorBelt> adjacentConveyors = new List<ConveyorBelt>();

    private void Start()
    {
        mainTileScript = this.GetComponent<MainTileScript>();
        neighbours = mainTileScript.neighbours;
        //adjacentConveyors = mainTileScript.adjacentConveyorBelts;
        orgPos = transform.position;
        FindNeighbours();
    }

    public void FindNeighbours()
    {
      
        neighbourCounter = 0;
        for (neighbourCounter = 0; neighbourCounter < 4; neighbourCounter++)
        {
            RaySender();
        }

        if (neighbours.Count == 4 && CompareTag("Conveyor") && GetComponent<UpgradeHandler>() && GetComponent<UpgradeHandler>().level == 1)
        {
            GetComponent<UpgradeHandler>().Upgrade(this);
//            Debug.Log(this.name + " Rotation : " + GetComponent<Transform>().rotation.z);
        }
        else if (hasAdjacent[0] && GetComponent<MainBuildingScript>())
        {
            GetComponent<Storage>().startingConveyor = neighbours[0].GetComponent<ConveyorBelt>();
        }
    }
    private void RaySender()
    {
        TargetChanger();

        //Sending Ray
        RaycastHit2D hit = Physics2D.Raycast(currentOriginPos, transform.TransformDirection(currentDirectionPos), 10f);
        //Checking whether or not hit is valid.
        if (hit)
        {
            //Check whether or not neighbours list contains this element.
            if (!DoesNeighbourContainsHit(hit) && !hit.transform.gameObject.CompareTag("Good"))
            {
                neighbours.Add(hit.collider.gameObject);
                CheckConveyors();
            }
        }
    }

    
    private void TargetChanger()
    {
        switch (neighbourCounter)
        {
            case 0:
                currentOriginPos = orgPos - x ;
                currentDirectionPos = Vector2.left;
                break;
            case 1:
                currentOriginPos = orgPos + x;
                currentDirectionPos = Vector2.right;
                break;
            case 2:
                currentOriginPos = orgPos + y;
                currentDirectionPos = Vector2.up;
                break;
            case 3:
                currentOriginPos = orgPos - y;
                currentDirectionPos = Vector2.down;
                break;
        }
    }

    private bool DoesNeighbourContainsHit(RaycastHit2D hit)
    {
        bool doesNeighboursContainsHit = neighbours.Contains(hit.collider.gameObject);
        return doesNeighboursContainsHit;
    }

    private void CheckConveyors()
    {
        foreach (GameObject neighbour in neighbours)
        {
            try
            {
                if (neighbour.CompareTag("Conveyor"))
                {
                    bool level1 = neighbour.GetComponent<UpgradeHandler>().level == 1;
                    bool level2 = neighbour.GetComponent<UpgradeHandler>().level == 2;    
                    if (level1  || level2)
                    {
                        Debug.Log("CheckConveyors:  " + this.name + " neighbour: " + neighbour.name );
                        int indexOfConveyor = neighbours.IndexOf(neighbour);
                        hasAdjacent[indexOfConveyor] = true;
                        //adjacentConveyors.Add(neighbour.GetComponent<ConveyorBelt >());
                    }
                }
                else if (neighbour.CompareTag("Buildings"))
                {
                    int indexOfBuilding = neighbours.IndexOf(neighbour);
                    hasAdjacent[indexOfBuilding] = true;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message + " This: " + this.name);
                throw;
            }
            
        }
    }
}