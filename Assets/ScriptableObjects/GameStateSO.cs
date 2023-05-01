using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game States", fileName = "Game State")]
public class GameStateSO : ScriptableObject
{
    public GameStateSO currentGameState;
    public GameStateSO purchase, bulldoze, play;
    public GameObject toPlace;
    public MouseMovementPlaceHolder gameObjectMouseOn;
    [SerializeField]
    private List<GameObject> conveyors = new List<GameObject>(4);
    public int currentConveyorIndex;

    [SerializeField] private List<Sprite> conveyorSprites = new List<Sprite>(4);

    private void OnEnable()
    {
        currentConveyorIndex = 0;
    }

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

    /// <summary>
    /// What its using
    /// </summary>
    /// <param name="conveyorsList">We need conveyors to place</param>>
    /// <param name="currentConveyorIndex">We need the index of current conveyor the player wants to place</param>>
    public void RotateTheConveyor()
    {
        //We need an array of conveyors
        if (toPlace.GetComponent<ConveyorBelt>())
        {
            Debug.Log("Index: " + currentConveyorIndex);
            if(++currentConveyorIndex == 4)
            {
                currentConveyorIndex = 0;
            }
            toPlace = conveyors[currentConveyorIndex];
            Debug.Log("IndexAfter: " + currentConveyorIndex);

        }
        //We sure need to change the placeholder too
        
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
        /*
         * Main conveyor is the right conveyor. this means, when we are selecting the conveyor in the building ui menu
         * right conveyor will show up in the scene at same point as mouse posiiton.
         * Then, how we change the direction of this conveyor?
         * We wont change its direction but we will change the conveyor.
         *  There must be 4 conveyor each ones direction is different.
         *  When we first select the conveyor in the building menu, first conveyor whose index on the its array is zero will show up.
         *  Then, if the player wants to change the direction of conveyor as his desire, he will push the R button.
         *  just after that, conveyorSelectionIndex will increase and it will assign the object on the array to toPlace field.
         *  When the index is equal to 3 and the R button is pressed, then the index will be equal to 0 again and this cycle will proceed.
         *
        */
        toPlace = buildable;
    }

    public Sprite GetSprite()
    {
        Debug.Log("GETSPRITE INDEX:" + currentConveyorIndex);
        return conveyorSprites[currentConveyorIndex];
    }
}
