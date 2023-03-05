using UnityEngine;
using TMPro;

[RequireComponent(typeof(RandomizeLoanValues))]
public class LoanManager : MonoBehaviour
{
    public LoanScriptableObject currentLoan, lastTakenLoan;

    [SerializeField] private float remainedTime = 0;
    [SerializeField] private FactoryResourcesSO factoryResourcesSo; 
    public bool HasLoan { get; set; }
    public bool hasDebtTaken;
    
    [SerializeField]
    private TextMeshProUGUI remainedTimeTxt;
    [SerializeField]
    private LoanScriptableObject[] loans;

    private RandomizeLoanValues randomizeLoanValues;


    private void Awake()
    {
        HasLoan = false;
        hasDebtTaken = false;
        randomizeLoanValues = GetComponent<RandomizeLoanValues>();
        foreach (var loan in loans)
        {
            loan.GetOwnValues();
            loan.RandomizeItsValues(randomizeLoanValues);
        }
    }

    private void Update()
    {
        if(HasLoan && remainedTime > 0)
            CountDown();
        else if (HasLoan && remainedTime <= 0 && !hasDebtTaken)
        {
            currentLoan.NotPaid(this, factoryResourcesSo, randomizeLoanValues);
            
        }
    }

    public void NewLoan(LoanScriptableObject loan)
    {
        if (!HasLoan)
        {
            remainedTime = loan.currentTimeToPay;
            HasLoan = true;
            hasDebtTaken = false;
            currentLoan = loan;
            loan.TakeTheMoney(this, factoryResourcesSo);
        }
        else
            Debug.LogError("YOU ALREADY HAVE A LOAN!");
    }

    private void CountDown()
    {
        remainedTime -= Time.deltaTime;
        int remainedTimeToShow = (int)remainedTime;
        remainedTimeTxt.text = remainedTimeToShow.ToString();
    }
}