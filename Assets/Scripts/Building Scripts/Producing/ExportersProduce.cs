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
        if (/*contractManager.HasContract && */storage.input >= consumeAmount)
        {
            Consume();
        }
    }

    public void Consume()
    {
        storage.input -= consumeAmount;
        Produce();
    }

    public void Produce()
    {
        if (currentContract != null)
        {
            currentContract.deliveredGoods += consumeAmount;
            float remainedGodsToDeliver = currentContract.currentOrderedGoods - currentContract.deliveredGoods;
        }
        else
        {
            Debug.Log("else");
            // We need to store those goods.
            Store();
        }
        //factoryResourcesSo.money += consumeAmount * factoryResourcesSo.contractGainPerExportedGood;
    }

    private void Store()
    {
        factoryResourcesSo.storedGoods += consumeAmount;
    }
}
