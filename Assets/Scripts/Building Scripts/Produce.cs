using System;
using UnityEngine;

public class Produce : MonoBehaviour
{
    /*#region Variables

    //Type 0: excavator, type 1: processor, type 2:  exporter
    private int produceAmount=10;
    private int consumeAmount=5;

    private MainBuildingScript mainBuildingScript;
    private Storage storage;

    [SerializeField]
    private FactoryResourcesSO factoryResourcesSO;
    #endregion 

    private void Start()
    {
        storage = this.GetComponent<Storage>();
        mainBuildingScript = this.GetComponent<MainBuildingScript>();
        InvokeRepeating(nameof(ProducingTypes), 0f, 1f);        
    }

    //unnecesarry switch case block.
    private void ProducingTypes()
    {
        switch(mainBuildingScript.type)
        {
            case 0:
                ProduceTypeOne();
                break;
            case 1:
                if(storage.input >= consumeAmount) 
                    ProduceTypeSecond();
                break;
            case 2:
                if(factoryResourcesSO.hasContract && storage.input >= consumeAmount)
                    ProduceTypeThird();
                break;                                
        }
    }


    #region Main Produce Section

    //These are basically a Produce() method
    //It should contain two different method: Consume() and Produce()
    private void ProduceTypeOne()
    {
        storage.output += produceAmount;
    }
 
    private void ProduceTypeSecond()
    {
        storage.output += produceAmount;
        storage.input -= consumeAmount;
    }
  
    private void ProduceTypeThird()
    {
        storage.input -= consumeAmount;
        factoryResourcesSO.money += consumeAmount * factoryResourcesSO.contractGainPerExportedGood;
    }
    #endregion*/
}
