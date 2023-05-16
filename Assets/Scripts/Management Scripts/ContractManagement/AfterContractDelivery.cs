using UnityEngine;

[RequireComponent(typeof(ContractManager))]
public class AfterContractDelivery : MonoBehaviour
{
    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    public void DeliveredSuccessfully(ContractScriptableObject contract)
    {
        factoryResourcesSo.money += contract.currentGain;
    }

    public void CouldNotDeliveredSuccessfully(ContractScriptableObject contract)
    {
        //He will pay lose money but also he must gain some money because has given some goods. 
        //We will find the money with this formula

        float moneyToAdd = contract.currentGain / contract.currentOrderedGoods * contract.deliveredGoods;
        factoryResourcesSo.money -= contract.currentLose - (int)moneyToAdd;
    }
}
