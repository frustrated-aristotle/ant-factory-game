using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript), typeof(RandomizeContractValues))]
public class ContractManager : MonoBehaviour
{
    [SerializeField]private float remainedTime;

    public bool HasContract { get; private set; }
    public bool HasTimeFinished { get; private set; }

    [SerializeField] private TextMeshProUGUI remainedTimeTxt;
    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    [SerializeField] private ContractScriptableObject[] contracts = new ContractScriptableObject[3];
    
    private AfterContractDelivery afterContractDelivery;
    private RandomizeContractValues randomizeContractValues;
    public  ContractScriptableObject currentContract, previousContract;

    private void Awake()
    {
        randomizeContractValues = GetComponent<RandomizeContractValues>();
        foreach (ContractScriptableObject contract in contracts)
        {
            contract.GetOwnValues();
            contract.RandomizeItsValues(randomizeContractValues);
        }
        HasTimeFinished = false;
        HasContract = false;
        afterContractDelivery = GetComponent<AfterContractDelivery>();
    }
    private void Update()
    {
        if (currentContract != null) TimeCheckForContract();
    }
    private bool HasGoodsDelivered()
    {
        if (currentContract.deliveredGoods < currentContract.currentOrderedGoods)
            return false;
        else
            return true;
    }
    private void TimeCheckForContract()
    {
        
        if (!HasTimeFinished && HasContract && remainedTime > 0)
        {
            if (!HasGoodsDelivered())
            {
                CountDown();
            }
            else
                ContractIsDelivered();
        }
        else if (remainedTime <= 0 && HasContract)
            CheckValuesForTheContract();
    }


    private void CheckValuesForTheContract()
    {
        if (HasGoodsDelivered())
            ContractIsDelivered();    
        else
            ContractIsNotDelivered();
    }
   
    private void ContractIsDelivered()
    {
        Debug.Log("Delivered");
        currentContract.RandomizeItsValues(randomizeContractValues);
        afterContractDelivery.DeliveredSuccessfully(currentContract);
        currentContract = previousContract;
        HasContract = false;
        currentContract = null;
    }

    private void ContractIsNotDelivered()
    {
        Debug.Log("Not Delivered");
        currentContract.RandomizeItsValues(randomizeContractValues);
        afterContractDelivery.CouldNotDeliveredSuccessfully(currentContract);
        currentContract = previousContract;
        HasContract = false;
        currentContract = null;
    }
    private void CountDown()
    {
        remainedTime -= Time.deltaTime;
        int remainedTimeToShow = (int)remainedTime;
        remainedTimeTxt.text = remainedTimeToShow.ToString();
    }

    public void NewContract(ContractScriptableObject newContract)
    {
        currentContract = newContract;
        HasContract = true;
        remainedTime = currentContract.currentDeliverTime;
    }
}