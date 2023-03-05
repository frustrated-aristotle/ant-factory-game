using UnityEngine;

public class ValueRandomizer : MonoBehaviour
{
    public int RandomizeTheValue(int variable, int min, int max)
    {
         variable = Random.Range(min, max);
         return variable;
    }
}
