using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int input;
    public int output;
    public int outputPerSecond;
    public ConveyorBelt startingConveyor;
    public GameObject good;

    private Vector3 posToInstantiate;

    private void Start()
    {
        InvokeRepeating(nameof(CreateGoodAtConveyorBelt), 0f, 1f);
    }
    
    #region Input Process

    public void TakeInput(int amount)
    {
        input += amount;
    }
    

    #endregion
    
    #region Output Process

    private void CreateGoodAtConveyorBelt()
    {
        if (startingConveyor != null)
        {
            posToInstantiate = startingConveyor.instantiationPos;
            if(CanGiveOutput())
            {
                for (int i = 0; i < outputPerSecond; i++)
                {
                    good.GetComponent<PackageMovementHandler>().firstConveyor = startingConveyor.GameObject();
                    GameObject a = Instantiate(good, posToInstantiate, quaternion.identity);
                }
            }
        }
    }

    private bool CanGiveOutput()
    {
        if (output > outputPerSecond)
        {
            return true;
        }
        return false;
    }

    #endregion

   
    
}
