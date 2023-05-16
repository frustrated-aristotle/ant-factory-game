﻿using UnityEngine;

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
        Debug.Log("has controact" + contractManager.HasContract + " and the current contract is " + contractManager.currentContract);
        if (contractManager.HasContract)
        {
            Debug.LogError("YOU HAVE ALREADY SELECTED A CONTRACT WHAT ARE YOU TRYING TO DO YOU CRAZY SON OF A B***");
        }
        else
        {
            ContractIsSelected(contract);
        }
    }

    private void ContractIsSelected(ContractScriptableObject contract)
    {
        contractManager.NewContract(contract);      
    }
}