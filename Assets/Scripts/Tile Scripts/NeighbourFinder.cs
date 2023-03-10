using System.Collections.Generic;
using UnityEngine;

public class NeighbourFinder : MonoBehaviour
{
    private Vector2 orgPos, currentOriginPos, currentDirectionPos;
    private Vector2 x = new Vector2(0.6f, 0);
    private Vector2 y = new Vector2(0, 0.5f);
    private int neighbourCounter;
    private MainTileScript mainTileScript;
    private List<GameObject> neighbours = new List<GameObject>();
    private void Start()
    {
        mainTileScript = this.GetComponent<MainTileScript>();
        neighbours = mainTileScript.neighbours;
        orgPos = transform.position;
        for (neighbourCounter = 0; neighbourCounter < 4; neighbourCounter++)
        {
            Debug.Log(neighbourCounter);
            RaySender();
        }
    }

    private void RaySender()
    {
        TargetChanger();
        Vector2 pos = transform.position;
        pos.y += 0.5f;
        //GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(currentOriginPos, transform.TransformDirection(currentDirectionPos), 10f);
        //GetComponent<BoxCollider2D>().enabled = true;
        if (hit)
        {
            Debug.Log("This: " + this + " and hit: " + hit.collider.name);
            //Check whether or not neighbours list contains this element.
            bool doesNeighboursContainsHit = neighbours.Contains(hit.collider.gameObject);
            if (!doesNeighboursContainsHit)
            {
                neighbours.Add(hit.collider.gameObject);
            }
            //If it does not, than add it.
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

}
