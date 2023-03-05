using UnityEngine;

public class BuildingCollideChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        //If the col object is a road, we need to assign this tile to that road as a starter point kinda thing.
        if(col.gameObject.layer == 9)
        col.transform.GetComponent<Road>().home = this.gameObject;

        //Transporters
        if(col.gameObject.layer == 8)
        col.gameObject.GetComponent<VehicleMovement>().ChangeTarget();
    }
}