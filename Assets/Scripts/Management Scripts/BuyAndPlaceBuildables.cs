using System.Linq;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class BuyAndPlaceBuildables : MonoBehaviour
{
    public void Buy(GameObject tile, GameObject prefab)
    {
        //We will place everything if it is buyable but vehicle. In case of buying a transporter, we first select both home and destiantion of the transporter.
        PlaceIt(tile, prefab);
    }

    private void PlaceIt(GameObject tile, GameObject prefab)
    {
        GameObject newBuildable = Instantiate(prefab, tile.transform.position, prefab.transform.rotation);
        newBuildable.GetComponent<MainTileScript>().neighbours = tile.GetComponent<MainTileScript>().neighbours;
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
}
