using UnityEngine;
using static GameStateManager;
public class MouseMovementPlaceHolder : MonoBehaviour
{
    //! this gamestateso will be changed to another specialized script file.

    public Sprite orgSprite;
    private TileMouseEnterExitHandler tileMouseEnterExitHandler;
    
    //States
    private GameStateManager stateManager;
    private void Start()
    {
        stateManager = GameObject.FindObjectOfType<GameStateManager>();
        tileMouseEnterExitHandler = GameObject.FindObjectOfType<TileMouseEnterExitHandler>();
       // orgSprite = GetComponent<SpriteRenderer>().sprite;

    }
    //! WE CAN SHOW THEIR SPRITE WITH ARROWS WHEN THE STATE IS PURCHASE.

    private void OnMouseEnter()
    {
        
        if (stateManager.AreStatesTheSame(States.PURCHASE))
        {
            Entered();
        }
    }

    public void Entered()
    {
        //We need to check the 
        if (stateManager.BuildableToPlace.GetComponent<ConveyorBelt>())
            GetComponent<SpriteRenderer>().sprite = stateManager.GetSprite();
            //GetComponent<SpriteRenderer>().sprite = currentState.toPlace.GetComponent<ConveyorBelt>().currentSprite;
        stateManager.gameObjectThatMouseIsOver = this.gameObject;
        
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = orgSprite;
    }
}