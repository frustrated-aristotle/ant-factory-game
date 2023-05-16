using System.Linq;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class BuyAndPlaceBuildables : MonoBehaviour
{
    private int i = 0;
    private GameObject prior;

    public GameObject defaultTile;

    [SerializeField] private FactoryResourcesSO factoryResourcesSo;
    public void Buy(GameObject tile, GameObject prefab, int level, int cost)
    {
        prior = tile;
        //We will place everything if it is buyable but vehicle. In case of buying a transporter, we first select both home and destiantion of the transporter.
        if (cost <= factoryResourcesSo.money)
        {
            factoryResourcesSo.money -= cost;
            PlaceIt(tile, prefab, level);
        }
        else
        {
            Debug.LogError("YOU DON'T HAVE ENOUGH MONEY YOU POOR BASTARD");
        }
    }

    private void PlaceIt(GameObject tileToBeReplaced, GameObject prefab, int level)
    {
        GameObject newBuildable= Instantiate(prefab, tileToBeReplaced.transform.position, prefab.transform.rotation);
        newBuildable.name = i.ToString();
        i++;
        ChangeParent(newBuildable);
        GetInheritedNeighbours(newBuildable, tileToBeReplaced);
        GetInheritedFields(newBuildable, tileToBeReplaced, level);
        Destroy(tileToBeReplaced);
        foreach (GameObject neighbour in newBuildable.GetComponent<MainTileScript>().neighbours.ToList())
        {
            neighbour.GetComponent<MainTileScript>().neighbours.Clear();
            neighbour.GetComponent<NeighbourFinder>().FindNeighbours();
        }   
        //newBuildable.GetComponent<MainTileScript>().neighbours.Clear();
    }

    private void GetInheritedFields(GameObject newBuildable, GameObject tile, int level)
    {
        if (newBuildable.GetComponent<UpgradeHandler>())
        {
            newBuildable.GetComponent<UpgradeHandler>().level = level;
        }
        if (newBuildable.GetComponent<ConveyorBelt>() && tile.GetComponent<ConveyorBelt>())
        {
            if (newBuildable.GetComponent<UpgradeHandler>().level == 2)
            {
                newBuildable.GetComponent<ConveyorBelt>().inheretedDirection = tile.GetComponent<ConveyorBelt>().direction;
            }
            newBuildable.GetComponent<ConveyorBelt>().spriteWithArrow = tile.GetComponent<ConveyorBelt>().spriteWithArrow;
        }
    }

    private void GetInheritedNeighbours(GameObject newBuildable, GameObject tile)
    {
        newBuildable.GetComponent<MainTileScript>().neighbours = tile.GetComponent<MainTileScript>().neighbours;
    }

    private void ChangeParent(GameObject newBuildable)
    {
        if (newBuildable.gameObject.CompareTag("Buildings"))
        {
            newBuildable.transform.parent = GameObject.Find("Buildings").transform;
        }
        else if (newBuildable.gameObject.CompareTag("Conveyor"))
        {
            newBuildable.transform.parent = GameObject.Find("Conveyors").transform;
        }
        else
        {
            newBuildable.transform.parent = GameObject.Find("ReplacedTiles").transform;
        }
    }
}
