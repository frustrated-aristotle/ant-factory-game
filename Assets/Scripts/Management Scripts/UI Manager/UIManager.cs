using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static GameStateManager.States;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject contractUI;
    [SerializeField] private GameObject loanUI;
    [SerializeField] private GameObject buildableUI;
    [SerializeField] private GameObject moneyUI;

    private DisplayContract displayContract;
    private DisplayLoan displayLoan;

    [SerializeField] private ConveyorManager conveyorManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    [SerializeField] private TextMeshProUGUI moneyText;

    //States
    private void Start()
    {
        displayContract = GameObject.FindObjectOfType<DisplayContract>();
        displayLoan = GameObject.FindObjectOfType<DisplayLoan>();
        gameStateManager = GameObject.FindObjectOfType<GameStateManager>();
        conveyorManager = GameObject.FindObjectOfType<ConveyorManager>();
    }

    private void Update()
    {
        KeyInputs();
        DisplayMoney();
    }

    private void DisplayMoney()
    {
        moneyText.text = factoryResourcesSo.money.ToString();
    }

    private void KeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.B) && !buildableUI.activeSelf)
        {
            gameStateManager.ChangeTheGameState(PURCHASE);
            //gameStateSo.MakeTheStatePurchaseState();
            buildableUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.B) && buildableUI.activeSelf)
        {
            buildableUI.SetActive(false);
           // gameStateSo.TurnRotationToZero();
            gameStateManager.ChangeTheGameState(NORMAL);
        }
        //Rotating Buildable
        else if (Input.GetKeyDown(KeyCode.R) && buildableUI.activeSelf)
        {
            gameStateManager.RotateTheConveyor();
        }
        else if (Input.GetKeyDown(KeyCode.C) && !contractUI.activeSelf)
        {
            gameStateManager.ChangeTheGameState(CONTRACTS);
            contractUI.SetActive(true);
            displayContract.DisplayAllContracts();
        }
        else if (Input.GetKeyDown(KeyCode.C) && contractUI.activeSelf)
        {
            contractUI.SetActive(false);
            gameStateManager.ChangeTheGameState(NORMAL);
        }
        else if (Input.GetKeyDown(KeyCode.L) && !loanUI.activeSelf)
        {
            loanUI.SetActive(true);
            displayLoan.DisplayAllLoans();
            gameStateManager.ChangeTheGameState(LOAN);
        }
        else if (Input.GetKeyDown(KeyCode.L) && loanUI.activeSelf)
        {
            loanUI.SetActive(false);
            gameStateManager.ChangeTheGameState(NORMAL);
        }
        else if (Input.GetKeyDown(KeyCode.O) && !conveyorManager.isDirectionOverlayOpened)
        {
            gameStateManager.ChangeTheGameState(DISPLAY);
            conveyorManager.isDirectionOverlayOpened = true;
            conveyorManager.ShowConveyorsDirection();
            
        }
        else if (Input.GetKeyDown(KeyCode.O) && conveyorManager.isDirectionOverlayOpened)
        {
            gameStateManager.ChangeTheGameState(DISPLAY);
            conveyorManager.isDirectionOverlayOpened = false;
            conveyorManager.HideConveyorsDirection();
        }
    }
}
