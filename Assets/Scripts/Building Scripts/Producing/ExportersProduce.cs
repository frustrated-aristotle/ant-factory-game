using UnityEngine;
using Building_Scripts;
using TMPro;

public class ExportersProduce : MainBuildingScript, IProduce
{
    [SerializeField]
    private FactoryResourcesSO factoryResourcesSo;
    public ContractScriptableObject currentContract;
    private ContractManager contractManager;
    [SerializeField]
    private TextMeshProUGUI remainedGoodsToDeliverTXT; 
    private void Start()
    {
        contractManager = GameObject.FindObjectOfType<ContractManager>();
        currentContract = contractManager.currentContract;
       //    remainedGoodsToDeliverTXT = GameObject.Find("RemainedGoodsToDeliverText").GetComponent<TextMeshProUGUI>();
    }
    public void StartProducingSequence()
    {
        if (contractManager.HasContract && storage.input >= consumeAmount)
        {
            Debug.Log("StartProcuidngSequence is working");
            Consume();
        }
    }

    public void Consume()
    {
        Debug.Log("Consume is working");
        storage.input -= consumeAmount;
        Produce();
    }

    public void Produce()
    {
        currentContract.deliveredGoods += consumeAmount;
        Debug.Log("current Contract: " + currentContract + " deliveredGoods: " + currentContract.deliveredGoods + " Consume amount : " + consumeAmount);
        factoryResourcesSo.money += consumeAmount * factoryResourcesSo.contractGainPerExportedGood;
        float remainedGodsToDeliver = currentContract.currentOrderedGoods - currentContract.deliveredGoods;
        remainedGoodsToDeliverTXT = GameObject.Find("RemainedGoodsToDeliverText").GetComponent<TextMeshProUGUI>();
        //remainedGoodsToDeliverTXT.text = remainedGodsToDeliver.ToString();  
        remainedGoodsToDeliverTXT.text = remainedGodsToDeliver.ToString();
    }
}
