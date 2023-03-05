using UnityEngine;

public class LandManager : MonoBehaviour
{
    public FactoryResourcesSO factoryResourcesSo;
    public GameObject[] areas;
    public GameObject[] uis;
    public Sprite mainSprite;
    
    public void BuyTheLand(LandScriptableObject land)
    {
        int order = land.order;
        land.area = areas[order];
        land.ui = uis[order];
        land.mainSprite = mainSprite;
        //Check if player has enough money
        //Check if the land has not already bought
        if (NecessityCheck(land))
        {
            Debug.Log(land.area);
            factoryResourcesSo.money -= land.cost;
            land.ItsBought();
        }
    }

    private bool NecessityCheck(LandScriptableObject land)
    {
        bool value;
        if(factoryResourcesSo.money >= land.cost)
        {
            if (!land.isBought)
            {
                value = true;
                return value;
            }
            else
                Debug.LogError("else");
        }
        else
        {
            Debug.LogError("You don't have enough money");
        }

        value = false;        
        return value;
    }
}
