using UnityEngine;

public class ImprovementHandler : MonoBehaviour
{
     //This will be fired by a button named Improve
     public void Improve(GameObject _improve)
     {
          
          IImprove improve = _improve.GetComponent<IImprove>();
          improve.TryToImprove();
     }
}
