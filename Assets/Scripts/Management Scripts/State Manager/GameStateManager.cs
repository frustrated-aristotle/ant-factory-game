using System.Collections.Generic;
using Building_Scripts;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private States currentState = States.NORMAL;
    
    //Conveyors:
    [SerializeField] public GameObject conveyorToPlace;
    [SerializeField] private GameObject buildableToPlace;
    [SerializeField] private List<GameObject> conveyors = new List<GameObject>(4);
    public int currentConveyorIndex;

    //Sprite
    [SerializeField] private List<Sprite> conveyorSprites = new List<Sprite>(4);
    
    //MouseMovement
    public GameObject gameObjectThatMouseIsOver;

    [SerializeField] private Sprite excavator, processor, exporter;

    #endregion

    #region Getters And Setters

    //Conveyor to Place Getter

    public GameObject ConveyorToPlace
    {
        get => buildableToPlace;
        private set => buildableToPlace = value;
    }

    public GameObject BuildableToPlace
    {
        get => buildableToPlace;
        private set => buildableToPlace = value;
    }
    #endregion
    public enum States
    {
        PURCHASE = 1,
        NORMAL = 0,
        BULLDOZE = 2,
        CONTRACTS = 3,
        LOAN = 4,
        DISPLAY,
        LANDS,
    }

    private void Awake()
    {
        currentConveyorIndex = 0;
    }

    #region Changing Builadble

    public void ChangeTheBuildableFromInspector(GameObject toBuild)
    {
        BuildableToPlace = toBuild;
    }

    public void ChangeTheBuildableFromCode(GameObject toBuild)
    {
        buildableToPlace = toBuild;
    }
    #endregion
    
    #region Rotating Conveyor

    public void RotateTheConveyor()
    {
        if (buildableToPlace.GetComponent<ConveyorBelt>())
        {
            if (++currentConveyorIndex == 4)
            {
                currentConveyorIndex = 0;
            }

            ConveyorToPlace = conveyors[currentConveyorIndex];
            BuildableToPlace = ConveyorToPlace;
        }
    }
    #endregion

    #region States

    public void ChangeTheGameState(States newState)
    {
        currentState = newState;
    }
    public bool AreStatesTheSame(States state)
    {
        return currentState == state;
    }

    #endregion

    #region Sprite
    public Sprite GetSprite()
    {
        if (buildableToPlace.GetComponent<MainBuildingScript>())
        {
            if (buildableToPlace.GetComponent<ExcavatorProduce>())
            {
                return excavator;
            }
            else if (buildableToPlace.GetComponent<ProcessorsProduce>())
            {
                return processor;
                
            }
            else if (buildableToPlace.GetComponent<ExportersProduce>())
            {
                return exporter;
            }
        }
        return conveyorSprites[currentConveyorIndex];
    }
    #endregion
}
