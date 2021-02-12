using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadNextLevel", 2f);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelUsingSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameQuitRequest()
    {
        Application.Quit();
    }
}
