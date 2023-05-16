using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void SceneLoadMethod(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
