using UnityEngine;

[RequireComponent(typeof(VehicleMovement))]
public class VehicleCollide : MonoBehaviour, ICollidable
{
    private VehicleMovement vehicleMovement;
    private VehicleStorage vehicleStorage;
    private void Start()
    {
        vehicleMovement = this.GetComponent<VehicleMovement>();
        vehicleStorage = this.GetComponent<VehicleStorage>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 7)
        {
            TakeAction(col);
        }
    }
    public void TakeAction(Collision2D col)
    {
        //Transportation works just one way: transporter takes output of the home and deliver it to destination as input of it.
        if(col.gameObject == vehicleMovement.realHome)
        {
            //vehicleMovement.realHome.GetComponent<Storage>().GiveOutput(vehicleStorage);
        }
        else if(col.gameObject == vehicleMovement.realDestination)
        {
            //vehicleMovement.realDestination.GetComponent<Storage>().TakeInput(vehicleStorage);
        }
    }
}
