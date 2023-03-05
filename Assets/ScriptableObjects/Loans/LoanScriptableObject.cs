using UnityEngine;

[CreateAssetMenu(fileName = "Loan", menuName = "Loans")]
public class LoanScriptableObject : ScriptableObject
{
    public float currentMoney;
    public float currentMoneyAfterInterest;
    public float currentInterest;
    public float currentTimeToPay;
    
    public float  mainMoney;
    public float  moneyAfterInterest;
    public float interest;
    public float timeToPay;

    public int type;

    public void NotPaid(LoanManager loanManager, FactoryResourcesSO factoryResourcesSo, RandomizeLoanValues randomizeLoanValues)
    {
        Debug.Log("Not Paid");
        factoryResourcesSo.money -= (int)currentMoneyAfterInterest;
        loanManager.HasLoan = false;
        loanManager.hasDebtTaken = true;
        RandomizeItsValues(randomizeLoanValues);
    }
    
    public void Paid(LoanManager loanManager, FactoryResourcesSO factoryResourcesSo, RandomizeLoanValues randomizeLoanValues)
    {
        factoryResourcesSo.money += (int)moneyAfterInterest;
        loanManager.lastTakenLoan = loanManager.currentLoan;
        loanManager.currentLoan = null;
        RandomizeItsValues(randomizeLoanValues);
    }

    public void TakeTheMoney(LoanManager loanManager, FactoryResourcesSO factoryResourcesSo)
    {
        factoryResourcesSo.money += (int)currentMoney;
    }

    public void GetOwnValues()
    {
        moneyAfterInterest = mainMoney + mainMoney * interest / 100;
        currentInterest = type * interest;
        currentMoneyAfterInterest = type * moneyAfterInterest;
        currentMoney = type * mainMoney;
        currentTimeToPay = type  * timeToPay;
    }

    public void RandomizeItsValues(RandomizeLoanValues randomizeLoanValues)
    {
        currentInterest = randomizeLoanValues.RandomizeTheValue((int)currentInterest);
        currentMoneyAfterInterest = randomizeLoanValues.RandomizeTheValue((int)currentMoneyAfterInterest);
        currentMoney = randomizeLoanValues.RandomizeTheValue((int)currentMoney);
        currentTimeToPay = randomizeLoanValues.RandomizeTheValue((int)currentTimeToPay);
    }
}