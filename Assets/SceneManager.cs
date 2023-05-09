using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void SceneLoadMethod()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/SampleScene");
    }
}
