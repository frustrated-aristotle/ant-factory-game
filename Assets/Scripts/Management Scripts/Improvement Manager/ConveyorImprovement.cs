using UnityEngine;

public class ConveyorImprovement : MonoBehaviour, IImprove
{
    [SerializeField] private int maxLevel;
    [SerializeField] private int impCost;
    private int currentLevel;

    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    public void TryToImprove()
    {
         Consume();   
    }

    public void Consume()
    {
        if (currentLevel <= maxLevel && factoryResourcesSo.money <= impCost)
        {
            
        }
        Improve();
    }

    public void Improve()
    {
        Debug.Log("Improve is just working");
    }
}
