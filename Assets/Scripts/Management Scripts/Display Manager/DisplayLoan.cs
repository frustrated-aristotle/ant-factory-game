    using TMPro;
using UnityEngine;

public class DisplayLoan : MonoBehaviour
{
    [SerializeField] private LoanScriptableObject[] loans = new LoanScriptableObject[3];
    [SerializeField] private TextMeshProUGUI[]  mainMoney = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[]  moneyAfterInterest = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[]  interest = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[]  timeToPay = new TextMeshProUGUI[3];

    public void DisplayAllLoans()
    {
        int i = 0;
        foreach (LoanScriptableObject loan in loans)
        {
            mainMoney[i].text = loan.currentMoney.ToString();
            moneyAfterInterest[i].text = loan.currentMoneyAfterInterest.ToString();
            interest[i].text = loan.currentInterest.ToString(); 
            timeToPay[i].text = loan.currentTimeToPay.ToString();
            i++;
        }
    }
}
