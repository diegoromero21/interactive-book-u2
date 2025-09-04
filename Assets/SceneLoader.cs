using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string homeScene = "MainMenu";

    public void LoadHome()
    {
        SceneManager.LoadScene(homeScene);
    }

    public void LoadNext()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        int count = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((i + 1) % count);
    }

    public void LoadBack()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        int count = SceneManager.sceneCountInBuildSettings;
        int prev = (i - 1 + count) % count;
        SceneManager.LoadScene(prev);
    }

    public void QuitApp()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
