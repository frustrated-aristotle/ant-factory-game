using UnityEngine;

public class RandomizeContractValues : MonoBehaviour
{
   public int RandomizeIt(int value, int maxRandom)
   {
      int randomPercentage = Random.Range(0, maxRandom);
      value += value * randomPercentage / 100;
      return value;
   }

   public int RandomizeMultiplier(int value, int maxRandom)
   {
      int random = Random.Range(0, maxRandom);
      value += random;
      return value;
   }
}
