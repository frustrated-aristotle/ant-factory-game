using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class BuyAndPlaceBuildables : MonoBehaviour
{
    public void Buy(GameObject tile, GameObject prefab)
    {
        //We will place everything if it is buyable but vehicle. In case of buying a transporter, we first select both home and destiantion of the transporter.
        PlaceIt(tile, prefab);
    }

    public void PlaceIt(GameObject tile, GameObject prefab)
    {
        //First, instatiate prefab
        GameObject a = Instantiate(prefab, tile.transform.position, prefab.transform.rotation);
        a.GetComponent<MainTileScript>().neighbours = tile.GetComponent<MainTileScript>().neighbours;
        foreach (var neighbour in a.GetComponent<MainTileScript>().neighbours)
        {
            int index = neighbour.GetComponent<MainTileScript>().neighbours.IndexOf(tile);
            neighbour.GetComponent<MainTileScript>().neighbours[index] = a;
        }
        Destroy(tile);
    }
}
