using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Contract", menuName = "Contract")]
public class ContractScriptableObject : ScriptableObject
{
    [Header(("Management"))] 
    public ContractManager manager;

    [Header("Image")]
    public Sprite image;

    [Header ("Properties To Show")]
    public string contractName;

    [Header("Current Variables")]
    public int currentOrderedGoods = 100;
    public int currentDeliverTime = 100;
    public int currentGain = 100;
    public int currentLose = 100;
    public int currentGainMultiplier = 10;
    public int currentLoseMultiplier = 10;
    
    [Header ("Base Properties")]
    public int mainOrderedGoods = 100;
    public int mainDeliverTime = 100;
    public int mainGain;
    public int mainLose;
    public int mainGainMultiplier = 10;
    public int mainLoseMultiplier = 10;


    [Header ("Properties That Will Be Change")]
    public float deliveredGoods;

    [Header("Type")] 
    public int type;
    
    public void UpscaleWhenItsCompleted()
    {
        mainDeliverTime += mainDeliverTime * 25 / 100;
        mainOrderedGoods += mainOrderedGoods * 25 / 100;
    }
    public void GetOwnValues()
    {
        currentDeliverTime = type *mainDeliverTime;
        currentOrderedGoods = type *mainOrderedGoods;
        currentGainMultiplier = mainGainMultiplier;
        currentLoseMultiplier = mainLoseMultiplier;
    }

    public void RandomizeItsValues(RandomizeContractValues randomizeContractValues)
    {
        currentGainMultiplier = randomizeContractValues.RandomizeMultiplier(currentGainMultiplier, 5);
        currentLoseMultiplier = randomizeContractValues.RandomizeMultiplier(currentLoseMultiplier, 5);
        currentDeliverTime = randomizeContractValues.RandomizeIt(currentDeliverTime , 11);
        currentOrderedGoods = randomizeContractValues.RandomizeIt(currentOrderedGoods, 11);
        currentGain = currentOrderedGoods * currentGainMultiplier;
        currentLose = currentOrderedGoods * currentLoseMultiplier;
        if (currentGain > currentLose)
        {
            currentLoseMultiplier = currentGainMultiplier + 1;
            currentLose = currentOrderedGoods * currentLoseMultiplier;
        }
    }
}