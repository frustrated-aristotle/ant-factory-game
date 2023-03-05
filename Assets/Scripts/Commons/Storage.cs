using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int input;
    public int output;
    public int outputRate;

    public GameObject good;
    public Road road;

    //When a transporter collides with a building, it either fulls his storage or empty it. 
    private void Start()
    {
        SendProducedToTheConveyor(road);
    }

    private void SendProducedToTheConveyor(Road road)
    {
        Instantiate(good, road.transform.position, quaternion.identity);
        
    }
    public void GiveOutput(VehicleStorage transporter)
    {
        //There are some cases:
        // output is equal to capacity
        //      give all of the output
        //  output is more than the capacity
        //      give the exact amount of capacity
        // output is less than the capacity
        //      give all of the output
        if(output > transporter.capacity)
        {
            output -= transporter.capacity;
            transporter.stored += transporter.capacity;
        }
        else if(output == transporter.capacity)
        {
            output -= transporter.capacity;
            transporter.stored += transporter.capacity;
        }
        else if(output < transporter.capacity)
        {
            transporter.stored += output;
            output -= output;
        }
    }

    public void TakeInput(VehicleStorage transporter)
    {
        // there are some cases here too:
        if(transporter.stored > 0)
        {
            input += transporter.stored;
            transporter.stored = 0;
        }
        
    }



}
