using UnityEngine;

public class RandomizeLoanValues : MonoBehaviour
{
    public int RandomizeTheValue(int value)
    {
        int randomPercentage = Random.Range(1, 11);
        value += value * randomPercentage / 100;
        return value;
    }
}