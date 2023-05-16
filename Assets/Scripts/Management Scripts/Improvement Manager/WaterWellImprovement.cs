using UnityEngine;
public class WaterWellImprovement : MonoBehaviour, IImprove
{
    public void TryToImprove()
    {
        Consume();   
    }

    public void Consume()
    {
        
        Improve();
    }

    public void Improve()
    {
        Debug.Log("Improve is just working");
    }
}
