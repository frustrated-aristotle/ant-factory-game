using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    [SerializeField] private List<ConveyorBelt> conveyors = new List<ConveyorBelt>();
    public bool isDirectionOverlayOpened = false;
    public void ShowConveyorsDirection()
    {
        GetConveyors();
        foreach (ConveyorBelt conveyor in conveyors)
        {
            conveyor.EnableDirections();
        }
    }

    private void GetConveyors()
    {
        conveyors = GameObject.FindObjectsOfType<ConveyorBelt>().ToList();
    }

    public void HideConveyorsDirection()
    {
        GetConveyors();
        foreach (ConveyorBelt conveyor in conveyors)
        {
            conveyor.UnableDirections();
        }
    }
    
}
