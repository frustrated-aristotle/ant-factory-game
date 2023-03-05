using UnityEngine;

public class FertileTileAssigner : MonoBehaviour
{
    public MainTileScript[] tiles;
    [SerializeField] private int homManyTilesAreFertile;
    [SerializeField] private Sprite fertileSprite;
    private void Awake()
    {
        GameObject area1 = GameObject.Find("Area1");
        AssignTilesAsFertile(area1);
    }

    public void AssignTilesAsFertile(GameObject area)
    {
        FindAllTiles(area);
        ChoseTilesToBeAssignedAsFertile(homManyTilesAreFertile);
    }

    private void FindAllTiles(GameObject area)
    {
        tiles = area.GetComponentsInChildren<MainTileScript>();
    }

    private void ChoseTilesToBeAssignedAsFertile(int count)
    {
        for (int i = 0; i < count; i++)
        {
            RandomNumber();
        }
        
        void RandomNumber()
        {
            int rand = ARandomNumber();
            if (!tiles[rand].isItFertile)
            {
                tiles[rand].GetComponent<SpriteRenderer>().sprite = fertileSprite;
                tiles[rand].isItFertile = true;
            }
            else
            {
                RandomNumber();
            }
        }
    }
    
    
    private int ARandomNumber()
    {
        int rand = Random.Range(0, tiles.Length);
        return rand;
    }
}
