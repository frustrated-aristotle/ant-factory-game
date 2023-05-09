using UnityEngine;

public class GameOverState : MonoBehaviour
{
    [SerializeField] private FactoryResourcesSO factoryResourcesSo;

    private void Update()
    {
        if (factoryResourcesSo.money < 0)
        {
            GameOver();            
        }
    }

    private void GameOver()
    {
        Debug.LogError("Game Over!");
        Time.timeScale = 0;
    }
}
