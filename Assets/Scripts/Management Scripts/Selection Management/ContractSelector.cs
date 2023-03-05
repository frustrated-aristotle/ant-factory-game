using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class ContractSelector : MonoBehaviour
{
    private ContractManager contractManager;

    private void Awake()
    {
        contractManager = GameObject.FindObjectOfType<ContractManager>();
    }

    public void SelectContract(ContractScriptableObject contract)
    {
        if (!contractManager.HasContract)
            ContractIsSelected(contract);
        else
            Debug.LogError("YOU HAVE ALREADY SELECTED A CONTRACT WHAT ARE YOU TRYING TO DO YOU CRAZY SON OF A B***");
    }

    private void ContractIsSelected(ContractScriptableObject contract)
    {
        contractManager.NewContract(contract);      
    }
}