using UnityEngine;

[CreateAssetMenu(menuName = "Game States", fileName = "Game State")]
public class GameStateSO : ScriptableObject
{
    public GameStateSO currentGameState;
    public GameStateSO purchase, bulldoze, play;
    public GameObject toPlace;
    public MouseMovementPlaceHolder gameObjectMouseOn;
    public bool IsTheStatePurchase()
    {
        bool returnValue = purchase == currentGameState ? true : false;
        return returnValue;
    }

    #region States

    public void MakeTheStatePurchaseState()
    {
        ChangeTheState(purchase);
    }
    
    //It will be fired by button on building ui.
    public void MakeTheStateBulldozeState()
    {
        ChangeTheState(bulldoze);
    }

    public void MakeTheStatePlay()
    {
        ChangeTheState(play);
    }
    
    #endregion
    
    public void ChangeTheState(GameStateSO state)
    {
        currentGameState = state;
    }

    public void Rotate()
    {
        //
        toPlace.transform.Rotate(0, 0,-90);
        Sprite currentSprite = toPlace.GetComponent<ConveyorBelt>().currentSprite;
        int index = toPlace.GetComponent<ConveyorBelt>().placeHolderSprites.IndexOf(currentSprite);
        index++;
        if (index >= 4)
        {
            index = 0;
        }
        currentSprite = toPlace.GetComponent<ConveyorBelt>().placeHolderSprites[index];
        toPlace.GetComponent<ConveyorBelt>().currentSprite = currentSprite;
        gameObjectMouseOn.Entered();
    }

    

    public void TurnRotationToZero()
    {
        if (toPlace.GetComponent<ConveyorBelt>())
        {
            toPlace.GetComponent<ConveyorBelt>().currentSprite = toPlace.GetComponent<ConveyorBelt>().spriteWithArrow;
            toPlace.transform.rotation = new Quaternion(0, 0, 0,0);
        }
    }
    public void ChangeTheBuildable(GameObject buildable)
    {
        toPlace = buildable;
    }
}
