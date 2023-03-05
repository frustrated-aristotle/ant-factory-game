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
        factoryResourcesSo.money -= contract.currentLose;
    }
}
