using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
