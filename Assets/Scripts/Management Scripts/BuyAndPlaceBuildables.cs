using System;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class BuyAndPlaceBuildables : MonoBehaviour
{
    [SerializeField]private GameStateSO gameStateSo;
    private int i = 0;

    [SerializeField] private GameObject defaultTile;
    public void Buy(GameObject tile, GameObject prefab, int level)
    {
        //We will place everything if it is buyable but vehicle. In case of buying a transporter, we first select both home and destiantion of the transporter.
        PlaceIt(tile, prefab, level);
    }

    private void PlaceIt(GameObject tile, GameObject prefab, int level)
    {
        GameObject newBuildable = Instantiate(prefab, tile.transform.position, prefab.transform.rotation);
        newBuildable.name = i.ToString();
        i++;
        if (newBuildable.gameObject.CompareTag("Buildings"))
        {
            newBuildable.transform.parent = GameObject.Find("Buildings").transform;
        }
        else
        {
            newBuildable.transform.parent = GameObject.Find("Conveyors").transform;
        }
        newBuildable.GetComponent<MainTileScript>().neighbours = tile.GetComponent<MainTileScript>().neighbours;
        if (newBuildable.GetComponent<UpgradeHandler>())
        {
            newBuildable.GetComponent<UpgradeHandler>().level = level;
        }
        //We can fire a funciton in neighbourfinder script that is for new conveyors. It will basically do the same job
        //but after finding neighbours.
        Destroy(tile);
        foreach (GameObject neighbour in newBuildable.GetComponent<MainTileScript>().neighbours.ToList())
        {
            neighbour.GetComponent<MainTileScript>().neighbours.Clear();
            //neighbour.GetComponent<MainTileScript>().adjacentConveyorBelts.Clear();
            neighbour.GetComponent<NeighbourFinder>().FindNeighbours();
            //int index = neighbour.GetComponent<MainTileScript>().neighbours.IndexOf(tile);
            //neighbour.GetComponent<MainTileScript>().neighbours[index] = newBuildable;
        }   
        newBuildable.GetComponent<MainTileScript>().neighbours.Clear();
    }

    public void PlaceNormalTile(GameObject gameObjectToDestroy)
    {
        Vector3 position = gameObjectToDestroy.transform.position;
        
        Destroy(gameObjectToDestroy);
        GameObject tileToPlace = defaultTile;
        GameObject a = Instantiate(tileToPlace, position, quaternion.identity);
        a.transform.parent = GameObject.Find("ReplacedTiles").transform;
    }
}
