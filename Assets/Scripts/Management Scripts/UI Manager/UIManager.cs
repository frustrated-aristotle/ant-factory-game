using System;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject contractUI;
    [SerializeField] private GameObject loanUI;
    [SerializeField] private GameObject buildableUI;

    public GameStateSO gameStateSo;

    private DisplayContract displayContract;
    private DisplayLoan displayLoan;
    private void Start()
    {
        displayContract = GameObject.FindObjectOfType<DisplayContract>();
        displayLoan = GameObject.FindObjectOfType<DisplayLoan>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !buildableUI.activeSelf)
        {
            gameStateSo.MakeStatePurchaseState();
            buildableUI.SetActive(true);
        }  
        else if (Input.GetKeyDown(KeyCode.B) && buildableUI.activeSelf)
        {
            buildableUI.SetActive(false);
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
