using UnityEngine;

public class LoanSelector : MonoBehaviour
{
    private LoanManager loanManager;
    [SerializeField]private FactoryResourcesSO factoryResourcesSo;
    private RandomizeLoanValues randomizeLoanValues;

    private void Start()
    {
        loanManager = GameObject.FindObjectOfType<LoanManager>();        
        randomizeLoanValues = GetComponent<RandomizeLoanValues>();

    }
    //will be fired by a button.
    public void SelectLoan(LoanScriptableObject selectedLoan)
    {
        if (!loanManager.HasLoan)
        {
            TakeLoan(selectedLoan);
        }
        else
            Debug.LogError("You already have a Loan, you can not take another one untill you pat it.");
    }

    private void TakeLoan(LoanScriptableObject selectedLoan)
    {
        loanManager.NewLoan(selectedLoan);
    }
    
    //Will be fired by a button.
    public void PayDebt()
    {
        int debt = (int)loanManager.currentLoan.moneyAfterInterest;
        int money = factoryResourcesSo.money;
        if (money >= debt)
        {
            loanManager.currentLoan.Paid(loanManager,factoryResourcesSo,randomizeLoanValues);
        }
        else
            Debug.LogError("You do not have enough money yoıu f'ing poor bastard.");
    }

}
