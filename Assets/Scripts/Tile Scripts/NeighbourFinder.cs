using System.Collections.Generic;
using UnityEngine;

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
    
    private List<GameObject> neighbours = new List<GameObject>();
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

        if (neighbours.Count == 4 && CompareTag("Conveyor") && GetComponent<UpgradeHandler>())
        {
            GetComponent<UpgradeHandler>().Upgrade(this);
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
            if (!DoesNeighbourContainsHit(hit))
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
            if (neighbour.CompareTag("Conveyor"))
            {
                int indexOfConveyor = neighbours.IndexOf(neighbour);
                hasAdjacent[indexOfConveyor] = true;
                //adjacentConveyors.Add(neighbour.GetComponent<ConveyorBelt >());
            }
        }
    }
}