using UnityEngine;

public class MouseMovementPlaceHolder : MonoBehaviour
{
    //! this gamestateso will be changed to another specialized script file.
    [SerializeField]
    private GameStateSO currentState;

    [SerializeField]private Sprite orgSprite;
    private TileMouseEnterExitHandler tileMouseEnterExitHandler;
    private void Start()
    {
        tileMouseEnterExitHandler = GameObject.FindObjectOfType<TileMouseEnterExitHandler>();
        currentState = GetComponent<MainTileScript>().gameState;
        orgSprite = GetComponent<SpriteRenderer>().sprite;

    }
    //! WE CAN SHOW THEIR SPRITE WITH ARROWS WHEN THE STATE IS PURCHASE.

    private void OnMouseEnter()
    {
        if (currentState.IsTheStatePurchase())
        {
            Entered();
        }
    }

    public void Entered()
    {
        //We need to check the 
        if (currentState.toPlace.GetComponent<ConveyorBelt>())
            GetComponent<SpriteRenderer>().sprite = currentState.GetSprite();
            //GetComponent<SpriteRenderer>().sprite = currentState.toPlace.GetComponent<ConveyorBelt>().currentSprite;
        currentState.gameObjectMouseOn = this;
        
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = orgSprite;
    }
}