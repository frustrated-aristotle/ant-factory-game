using UnityEngine;
using Building_Scripts;
using TMPro;

public class ExportersProduce : MainBuildingScript, IProduce
{
    [SerializeField]
    private FactoryResourcesSO factoryResourcesSo;
    private ContractScriptableObject currentContract;
    private ContractManager contractManager;
    [SerializeField]
    private TextMeshProUGUI remainedGoodsToDeliverTXT; 
    private void Start()
    {
        contractManager = GameObject.FindObjectOfType<ContractManager>();
        currentContract = contractManager.currentContract;

    }
    public void StartProducingSequence()
    {
        if(contractManager.HasContract && storage.input >= consumeAmount)
            Consume();
    }

    public void Consume()
    {
        storage.input -= consumeAmount;
        Produce();
    }

    public void Produce()
    {
        currentContract.deliveredGoods += consumeAmount;
        factoryResourcesSo.money += consumeAmount * factoryResourcesSo.contractGainPerExportedGood;
        float remainedGodsToDeliver = currentContract.currentOrderedGoods - currentContract.deliveredGoods;
        remainedGoodsToDeliverTXT = GameObject.Find("RemainedGoodsToDeliverText").GetComponent<TextMeshProUGUI>();
        //remainedGoodsToDeliverTXT.text = remainedGodsToDeliver.ToString();  
        remainedGoodsToDeliverTXT.text = "a";
    }
}
