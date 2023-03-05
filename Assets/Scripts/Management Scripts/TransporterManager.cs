using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class TransporterManager : MonoBehaviour
{
    public GameObject home, destination, transporter;
    public void BuyAndPlaceTransporter(List<Transform> path)
    {
        //When the player clicks on a building in purchase mode,
        //The first click will be the destination.
        //  If the player changes his mind and not want that tile to be the transporters home
        //      he will left click at somewhere. This will clear the home variable.
        //      After that, he needs to choose a home again.
        //When the player clicks on a building in purchase mode,
        //If the roadManager's home variable is not null,
        //this tile will be the destination tile.
        
        //We will assign home and destination vars to the vehicle.
        transporter.GetComponent<VehicleMovement>().realPath = path;
        transporter.GetComponent<VehicleMovement>().realDestination = destination;
        transporter.GetComponent<VehicleMovement>().realHome = home;
        transporter.GetComponent<VehicleMovement>().isNew = true;
        Instantiate(transporter, homePosition(), Quaternion.identity);
        foreach (Transform tr in path)
        {
            Debug.Log("Path tra: " + tr.position);
        }
        ClearVars();
    }

    private void ClearVars()
    {
        home = null;
        destination = null;
    }

    private Vector3 homePosition()
    {
        Vector3 newPos = home.transform.position;
        newPos.z = -0.75f;
        return newPos;
    }
}
