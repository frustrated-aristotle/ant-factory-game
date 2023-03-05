using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RequiredGameManagerScript))]
public class ProduceDelegator : MonoBehaviour
{
    public List<IProduce> producers = new List<IProduce>();
    
    
    private void Start()
    {
        InvokeRepeating(nameof(Produce), 0f, 1f);
    }

    private void Produce()
    {
        foreach (IProduce producer in producers)
        {
            producer.StartProducingSequence();
        }
    }
}
