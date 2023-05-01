using TMPro;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject contractUI;
    [SerializeField] private GameObject loanUI;
    [SerializeField] private GameObject buildableUI;
    [SerializeField] private GameObject moneyUI;

    public GameStateSO gameStateSo;

    private DisplayContract displayContract;
    private DisplayLoan displayLoan;

    
    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        displayContract = GameObject.FindObjectOfType<DisplayContract>();
        displayLoan = GameObject.FindObjectOfType<DisplayLoan>();
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
            gameStateSo.MakeTheStatePurchaseState();
            buildableUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.B) && buildableUI.activeSelf)
        {
            buildableUI.SetActive(false);
            gameStateSo.TurnRotationToZero();
            gameStateSo.MakeTheStatePlay();
            
        }
        //Rotating Buildable
        else if (Input.GetKeyDown(KeyCode.R) && buildableUI.activeSelf)
        {
            gameStateSo.Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.C) && !contractUI.activeSelf)
        {
            contractUI.SetActive(true);
            displayContract.DisplayAllContracts();
        }
        else if (Input.GetKeyDown(KeyCode.C) && contractUI.activeSelf)
        {
            contractUI.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.L) && !loanUI.activeSelf)
        {
            loanUI.SetActive(true);
            displayLoan.DisplayAllLoans();
        }
        else if (Input.GetKeyDown(KeyCode.L) && loanUI.activeSelf)
        {
            loanUI.SetActive(false);
        }
    }
}
