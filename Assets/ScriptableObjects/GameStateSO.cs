using UnityEngine;

[CreateAssetMenu(menuName = "Game States", fileName = "Game State")]
public class GameStateSO : ScriptableObject
{
    public GameStateSO currentGameState;
    public GameStateSO purchase, bulldoze;
    public GameObject toPlace;
    public bool IsTheStatePurchase()
    {
        bool returnValue = purchase == currentGameState ? true : false;
        return returnValue;
    }

    #region States

    public void MakeStatePurchaseState()
    {
        ChangeTheState(purchase);
    }
    
    //It will be fired by button on building ui.
    public void MakeStateBulldozeState()
    {
        ChangeTheState(bulldoze);
    }
    
    #endregion
    
    private void ChangeTheState(GameStateSO state)
    {
        currentGameState = state;
    }

    public void ChangeTheBuildable(GameObject buildable)
    {
        toPlace = buildable;
    }
    
}
