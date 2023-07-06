using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static GameStateManager.States;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class UIManager : MonoBehaviour
{
    private GameObject activeUI;
    [SerializeField] private GameObject contractUI;
    [SerializeField] private GameObject loanUI;
    [SerializeField] private GameObject buildableUI;
    [SerializeField] private GameObject moneyUI;
    [SerializeField] private GameObject landsUI;
    [SerializeField] private GameObject infoUI;
    
    
    private DisplayContract displayContract;
    private DisplayLoan displayLoan;

    [SerializeField] private ConveyorManager conveyorManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI storedWheatText;

    
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
        DisplayStoredGoods();
    }

    private void DisplayMoney()
    {
        moneyText.text = factoryResourcesSo.money.ToString();
    }

    private void DisplayStoredGoods()
    {
        storedWheatText.text = factoryResourcesSo.storedGoods.ToString();
    }

    private void KeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.B) && !buildableUI.activeSelf)
        {
            OpenUI(buildableUI);
            gameStateManager.ChangeTheGameState(PURCHASE);
        }
        else if (Input.GetKeyDown(KeyCode.B) && buildableUI.activeSelf)
        {
            CloseUI(buildableUI);
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
            OpenUI(contractUI);
            gameStateManager.ChangeTheGameState(CONTRACTS);
            displayContract.DisplayAllContracts();
        }
        else if (Input.GetKeyDown(KeyCode.C) && contractUI.activeSelf)
        {
            CloseUI(contractUI);
            gameStateManager.ChangeTheGameState(NORMAL);
        }
        else if (Input.GetKeyDown(KeyCode.L) && !loanUI.activeSelf)
        {
            OpenUI(loanUI);
            loanUI.SetActive(true);
            displayLoan.DisplayAllLoans();
            gameStateManager.ChangeTheGameState(LOAN);
        }
        else if (Input.GetKeyDown(KeyCode.L) && loanUI.activeSelf)
        {
            CloseUI(loanUI);
            gameStateManager.ChangeTheGameState(NORMAL);
        }
        else if (Input.GetKeyDown(KeyCode.Z) && !landsUI.activeSelf)
        {
            OpenUI(landsUI);
            landsUI.SetActive(true);
            gameStateManager.ChangeTheGameState(LANDS);
        }
        else if (Input.GetKeyDown(KeyCode.Z) && landsUI.activeSelf)
        {
            CloseUI(landsUI);
            gameStateManager.ChangeTheGameState(NORMAL);
        }
        else if (Input.GetKeyDown(KeyCode.N) && !infoUI.activeSelf)
        {
            OpenUI(infoUI);
            landsUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.N) && infoUI.activeSelf)
        {
            CloseUI(infoUI);            
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

    private void OpenUI(GameObject toBeOpened)
    {
        if (activeUI != null)
        {
            GameObject toBeClosed = activeUI;
            toBeClosed.SetActive(false);
        }
        activeUI = toBeOpened;
        toBeOpened.SetActive(true);
    }

    private void CloseUI(GameObject toBeClosed)
    {
        toBeClosed.SetActive(false);
        activeUI = null;
    }
}
