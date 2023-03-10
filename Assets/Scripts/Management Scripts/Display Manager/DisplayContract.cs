using TMPro;
using UnityEngine;

public class DisplayContract : MonoBehaviour
{
    [SerializeField] private ContractScriptableObject[] contracts = new ContractScriptableObject[3];
    [SerializeField] private TextMeshProUGUI[]  deliverGood = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[]  money = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[]  deliverTime = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[]  loseAMount = new TextMeshProUGUI[3];
   
    public void DisplayAllContracts()
    {
        int i = 0;
        foreach (ContractScriptableObject contract in contracts)
        {
            deliverGood[i].text = contract.currentOrderedGoods.ToString();
            money[i].text = contract.currentGain.ToString();
            deliverTime[i].text = contract.currentDeliverTime.ToString();
            loseAMount[i].text = contract.currentLose.ToString();
            i++;
        }
    }
}