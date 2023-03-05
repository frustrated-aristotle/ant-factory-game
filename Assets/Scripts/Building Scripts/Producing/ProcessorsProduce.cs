using Building_Scripts;

public class ProcessorsProduce : MainBuildingScript, IProduce
{
    public void StartProducingSequence()
    {
        if(storage.input >= consumeAmount) 
            Consume();
    }

    public void Consume()
    {   
        storage.input -= consumeAmount;
        Produce();
    }

    public void Produce()
    {
        storage.output += produceAmount;
    }
}
