using Building_Scripts;
using UnityEngine;

public class ExcavatorProduce : MainBuildingScript, IProduce
{
    public void StartProducingSequence()
    {
        Consume();
    }

    public void Consume()
    {   
        Produce();
    }

    public void Produce()
    {
        storage.CreateGoodAtConveyorBelt();
        storage.output += produceAmount;
    }
}
