using System;
using UnityEngine;

public class PathCreationManager : MonoBehaviour
{
    private String state = "Path Creation";
    public MainTileScript home ,target;
    public GameStateSO currentGameState;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //currentGameState.currentGameState = state;
        }

      /*  if (currentGameState.currentGameState == state && Input.GetKeyDown(KeyCode.P) )
        {
            //We need to check if the last member of home's path is not the target, then it supposed to not work.
        }*/
    }

    public void AddTheRoadToHomeAsWayPoint(Transform wayPoint)
    {
        home.path.Add(wayPoint);
    }

    public void AddTheTargetToTheEndOfThePath(Transform _target)
    {
        home.path.Add(_target);
        foreach (Transform tra in home.path)
        {
            Debug.Log("Nodes: " + tra.position);
        }
        //This means the path is completed.
        //currentGameState.currentGameState = "Purchase";
        home = null;
        target = null;
        //Now we can instantiate our road.
    }

    public void AddTheTargetToTheFrontOfThePath(Transform _home)
    {
        home.path.Insert(0, _home);
        //home.path.Add(_home);
    }
}
