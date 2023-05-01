using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseMovementPlaceHolder : MonoBehaviour
{
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
        if(currentState.toPlace.GetComponent<ConveyorBelt>())
            GetComponent<SpriteRenderer>().sprite = currentState.toPlace.GetComponent<ConveyorBelt>().currentSprite;
        currentState.gameObjectMouseOn = this;
        
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = orgSprite;
    }
}